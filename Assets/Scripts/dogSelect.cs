using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class dogSelect : MonoBehaviour
{
    public Light selectLight;
    public static string selected;
    // Start is called before the first frame update
    void Start()
    {
        selectLight.enabled = false;
        selected = "";
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
        selected = this.gameObject.name;
        SceneManager.LoadScene("MapSelect");
    }
    void OnMouseExit()
    {
        selectLight.enabled = false;
    }
}
