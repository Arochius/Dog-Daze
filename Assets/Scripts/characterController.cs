using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;
public class characterController : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public GameObject dog;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }

        if (controller.transform.position.y <= -40)
        {
            SceneManager.LoadScene("EndGameScene");
        }

        moveDirection.y -= gravity * Time.deltaTime;
        if (ThirdPersonCharacter.isPissing)
            speed = 0;
        else speed = 6.0f;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
