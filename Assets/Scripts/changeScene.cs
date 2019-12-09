﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public static string selectedDog;
    public static string selectedMap;
    public static string difficulty;

    GameObject[] doggos;

    private void Start()
    {
        selectedDog = "";
    }

    public void characterScene()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void mapScene(Button button)
    {
        difficulty = button.name;
        print(difficulty);
        SceneManager.LoadScene("MapSelect");
    }

    public void titleScene()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void retry()
    {
        selectedDog = dogSelect.selected;
        SceneManager.LoadScene(selectedMap);
    }

   
    public void endGame()
    {
        Application.Quit();
    }

   

    public void protomapScene()
    {
        selectedDog = dogSelect.selected;
        selectedMap = "Level1";
        SceneManager.LoadScene(selectedMap);
    }
    public void protomapScene2()
    {
        selectedDog = dogSelect.selected;
        selectedMap = "Level2";
        SceneManager.LoadScene(selectedMap);
    }
}