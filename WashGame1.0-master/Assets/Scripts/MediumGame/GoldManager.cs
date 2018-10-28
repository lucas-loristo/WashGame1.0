using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour {

    //int money;
    //public Text moneydisplay;
    public float speed;


	// Use this for initialization
	void Start () {
        //moneydisplay.text = PlayerPrefs.GetInt("Currency").ToString();
        //money = PlayerPrefs.GetInt("Currency");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // increase money of 1
            other.GetComponent<Player>().money += 1;
            other.GetComponent<Player>().moneydisplay.text = other.GetComponent<Player>().money.ToString();

            PlayerPrefs.SetInt("Currency", other.GetComponent<Player>().money);
            Destroy(gameObject);


        }
    }
}
