using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{

    public void characterScene()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void titleScene()
    {
        SceneManager.LoadScene("TitleScreen");
    }
 
    public void protomapScene()
    {
        SceneManager.LoadScene("ProtoLevel");
    }
    public void endGame()
    {
        Application.Quit();
    }
}