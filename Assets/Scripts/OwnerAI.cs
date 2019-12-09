using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class OwnerAI : MonoBehaviour
{
    public Transform[] targets; // list of potential targets         targets[0] = GameObject.FindGameObjectWithTag("Player").transform;
    private Transform target = null;
    private float chaseSpeed = 0f;
    public float wanderingSpeed = 2f;

    

    NavMeshAgent nav;
    Animator anim;
    public float headOffset = 1.5f; // the origin of this character is at the feet. we want to cast rays from the eyes
    public float FOV = 110f; // how wide the zombie's field of view is in degrees

    float lastStateChangeTime; //when was the last time we changed state
    public float stateChangeInterval = 15f; // how often to change state
    public RuntimeAnimatorController controller;

    enum ZombieState { chasing = 0, biting = 1, wandering = 2 }; // different states of the zombie
    ZombieState state = ZombieState.wandering;

    //Audio
    public AudioClip chasingSound;
    public AudioClip spottedSound;
    public AudioClip caughtSound;
    public AudioSource audio;

    bool didSpot;

    // initialization
    void Start()
    {
        if (changeScene.difficulty == "easy")
        {
            chaseSpeed = 3.4f;
        } else if (changeScene.difficulty == "medium")
        {
            chaseSpeed = 5.2f;
        } else
        {
            chaseSpeed = 6f;
        }
        
        Random.seed = (int)System.DateTime.Now.Ticks;
        nav = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        lastStateChangeTime = Time.time;
        audio = GetComponent<AudioSource>();
    }

    // try to find a target. if no target is found, wander. if a target is found, chase it.
    void FixedUpdate()
    {
        
            if (!Targeting())
                Wandering();
            if (target && !state.Equals("chasing"))
            {
                Chasing();
                if (!didSpot)
                {
                    audio.PlayOneShot(spottedSound);
                    didSpot = true;
                }
            }
    }

    //gets a random point on a circle around the zombie to decide where to wander to. OR stays idle for a little while
    void Wandering()
    {
        if (Time.time > lastStateChangeTime + stateChangeInterval)
        {
            lastStateChangeTime = Time.time;
            if (Random.Range(0, 100) > 40)
            { // go to random destination
                Vector2 vec2 = GetRandomOnCircle(Random.Range(20f, 50f));

                nav.destination = new Vector3(transform.position.x + vec2.x, transform.position.y, transform.position.z + vec2.y);
                print("wandering change" + gameObject.name + " " + nav.destination);
                nav.speed = wanderingSpeed;

                anim.SetFloat("Speed", wanderingSpeed);
                anim.SetBool("isRunning", false);
            }
            else
            { // play an idle animation
                nav.destination = transform.position;
                print("idle change" + gameObject.name);
                nav.speed = 0f;

                anim.SetFloat("Speed", 0f);
                anim.SetBool("isRunning", false);
            }
        }
    }

    //chase the target
    void Chasing()
    {
        anim.SetFloat("Speed", chaseSpeed); // running animation speed
        anim.SetBool("isRunning", true); //trigger run animation

        nav.destination = target.position; //set the target
        nav.speed = chaseSpeed; // actual speed of movement

    }

    // Check to see if the zombie can see a target. If so, return true. Else, return false.
    bool Targeting()
    {
        if (!target)
        {
            didSpot = false;
            Vector3 dir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
            RaycastHit hit = new RaycastHit();
            Debug.DrawLine(transform.position + Vector3.up * headOffset, GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up * headOffset / 2, Color.red);

            Debug.DrawLine(transform.position + Vector3.up * headOffset, (transform.position + Vector3.up * headOffset) + transform.forward);

            //logic for modeling the zombie's field of view and make sure the potential target is not a zombie
            if (Mathf.Acos(Vector3.Dot(transform.forward, Vector3.Normalize(dir))) < Mathf.Deg2Rad * (FOV / 2f)
                && Physics.Raycast(transform.position + Vector3.up * headOffset / 2, dir, out hit)
                    && hit.collider.gameObject.tag.Equals("Player"))
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;

                state = ZombieState.chasing;
                print(hit.collider.gameObject.tag);
                return true;
            }

        }
        return false;

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.tag.Equals("Player"))
        {
            audio.PlayOneShot(caughtSound);
            //anim.SetTrigger("Attack");
            //anim.SetBool("isAttacking", true);
            //anim.SetFloat("Speed", 0);
            //anim.SetBool("isRunning", false);
            //state = ZombieState.biting;
            //float force = 3;
            //other.collider.GetComponent<Rigidbody>().AddForce(transform.forward*3);
        }
    }
    /*
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.gameObject.tag.Equals("Player"))
        {
            anim.SetBool("isAttacking", false);
        }
    }
    */

    Vector2 GetRandomOnCircle(float radius)
    {

        // initialize calculation variables
        float _x = 0;
        float _y = 0;
        Vector2 _returnVector;

        // convert degrees to radians
        float angleRadians = Random.Range(-1f, 1f);
        float angleRadians2 = Random.Range(-1f, 1f);

        // get the 2D dimensional coordinates
        _x = radius * Mathf.Cos(angleRadians);
        _y = radius * Mathf.Sin(angleRadians2);

        // derive the 2D vector
        _returnVector = new Vector2(_x, _y);

        // return the vector info
        return _returnVector;
    }
}
