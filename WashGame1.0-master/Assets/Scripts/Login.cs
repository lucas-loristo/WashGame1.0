using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine;
using System;
using System.IO;

public class Login : MonoBehaviour {

	public InputField usernameField;
	public InputField passwordField;
    string path;
    string jsonString;

	public Button submitButton;

    private void Start()
    {
        
        path = Application.streamingAssetsPath + "/UserData.json";

    }


    public void CallLogin(){
			StartCoroutine(TryLogin());
	}

	IEnumerator TryLogin(){
		WWWForm form = new WWWForm();
		form.AddField("username", usernameField.text);
		form.AddField("password", passwordField.text);

		WWW myWWW = new WWW("http://localhost/wash-admin/public/login", form);

		yield return myWWW;

        string jsonData = "";


        if (string.IsNullOrEmpty(myWWW.error)) {

            //DO NOT TOUCH THIS SHIT, TO DECODE JSON USE THIS
            jsonData = myWWW.text;
            jsonData = jsonData.Replace("\"{", "{");
            jsonData = jsonData.Replace(@"}""", "}");
            jsonData = jsonData.Replace(@"\", "");

            Debug.Log(jsonData);
            StreamWriter mySW = new StreamWriter(path);

            using (mySW)
            {

                mySW.WriteLine(jsonData);
                mySW.Close();
            }

            Resp theResp = JsonUtility.FromJson<Resp>(jsonData);

            Debug.Log(jsonData);
            Debug.Log(theResp.connection);

            if(theResp.connection == "connected")
            {
                SceneManager.LoadScene("Instruction");
            }
        }

	}
   
    // public void verifyInputs(){
    // 	submitButton.interactable = (nameField.text.lenth)
    // }
}

[System.Serializable]
public class Resp
{
    public string connection;
    public int userID;
}
