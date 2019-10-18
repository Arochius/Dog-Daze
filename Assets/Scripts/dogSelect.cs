using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class dogSelect : MonoBehaviour
{
    public Light selectLight;
    // Start is called before the first frame update
    void Start()
    {
        selectLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        selectLight.enabled = true;
       
    }
    void OnMouseDown()
    {
        SceneManager.LoadScene("MapSelect");

    }
    void OnMouseExit()
    {
        selectLight.enabled = false;
    }
}
