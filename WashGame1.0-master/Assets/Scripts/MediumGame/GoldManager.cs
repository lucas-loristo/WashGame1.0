using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{

    //int money;
    //public Text moneydisplay;
    public float speed;
    string path;
    string jsonString;
    int theMoney;


    // Use this for initialization
    void Start()
    {
        //moneydisplay.text = PlayerPrefs.GetInt("Currency").ToString();
        //money = PlayerPrefs.GetInt("Currency");

        path = Application.streamingAssetsPath + "/UserData.json";
        jsonString = File.ReadAllText(path);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // increase money of 1
            other.GetComponent<Player>().money += 1;
            other.GetComponent<Player>().moneydisplay.text = other.GetComponent<Player>().money.ToString();

            AddMoney(1);

            //PlayerPrefs.SetInt("Currency", other.GetComponent<Player>().money);
            Destroy(gameObject);


        }
    }

    private void AddMoney(int Money)
    {
        newResp user = JsonUtility.FromJson<newResp>(jsonString);

        WWWForm form = new WWWForm();
     
        form.AddField("userID", user.userID);
        form.AddField("amountToAdd", Money);

        WWW newWWW = new WWW("http://localhost/wash-admin/public/addMoney", form);
         
        string response = "";

        if (newWWW.isDone)
        {

        Debug.Log(newWWW.text);

        if (string.IsNullOrEmpty(newWWW.error))
        {
            response = newWWW.text;
            response = response.Replace("\"{", "{");
            response = response.Replace(@"}""", "}");
            response = response.Replace(@"\", "");

            balance newBal = JsonUtility.FromJson<balance>(response);

            Debug.Log(newBal.washPoints.ToString());
            PlayerPrefs.SetInt("Currency", newBal.washPoints);
        }
        }

    
    }
}

[System.Serializable]
public class newResp
{
    public string connection;
    public int userID;
}

    [System.Serializable]
    public class balance
    {
        public int washPoints;
    }