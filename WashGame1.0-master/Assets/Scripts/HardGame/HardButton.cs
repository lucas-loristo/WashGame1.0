using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardButton : MonoBehaviour {

    public void HardDifficulty()
    {
        SceneManager.LoadScene("HardGame");
    }
}
