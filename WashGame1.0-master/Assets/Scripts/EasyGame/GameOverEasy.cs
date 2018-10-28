﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverEasy : MonoBehaviour
{

    public GameObject flashText;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("flashTheText", 0f, 0.5f);
    }

    // Update is called once per frame
    public void PlayAgainEasy()
    {
        SceneManager.LoadScene("EasyGame");
    }

    void flashTheText()
    {
        if (flashText.activeInHierarchy)
            flashText.SetActive(false);
        else
            flashText.SetActive(true);
    }
}
