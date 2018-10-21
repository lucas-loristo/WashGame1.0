using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject flashText;

	// Use this for initialization
	void Start () {
        InvokeRepeating("flashTheText", 0f, 0.5f);
	}

    
    public void PLayGame()
    {
        SceneManager.LoadScene("Instruction");
    }

    void flashTheText()
    {
        if (flashText.activeInHierarchy)
            flashText.SetActive(false);
        else
            flashText.SetActive(true);
    }
}
