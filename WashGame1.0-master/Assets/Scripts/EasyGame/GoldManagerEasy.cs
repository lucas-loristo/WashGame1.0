using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManagerEasy : MonoBehaviour {

    //int money;
    //public Text moneydisplay;
    public float speed;


    // Use this for initialization
    void Start() {
        //moneydisplay.text = PlayerPrefs.GetInt("Currency").ToString();
        //money = PlayerPrefs.GetInt("Currency");
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // increase money of 1
            other.GetComponent<PlayerEasy>().money += 1;
            other.GetComponent<PlayerEasy>().moneydisplay.text = other.GetComponent<PlayerEasy>().money.ToString();

            PlayerPrefs.SetInt("Currency", other.GetComponent<PlayerEasy>().money);
            Destroy(gameObject);


        }
    }
}
