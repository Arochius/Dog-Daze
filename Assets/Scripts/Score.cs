using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class Score : MonoBehaviour
{
    public static int score;
    public static int scoreToWin;
    public Text scoreText;
    public static bool didWin;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreToWin = 5;
        didWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        score = ThirdPersonCharacter.pissCounter;
        scoreText.text = "Score: " + score;
        if (score >= scoreToWin)
        {
            didWin = true;
            SceneManager.LoadScene("EndGameScene");
        }
    }
}