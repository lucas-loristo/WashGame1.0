using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine;
using System;

public class Login : MonoBehaviour {

	public InputField usernameField;
	public InputField passwordField;

	public Button submitButton;


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


		if (string.IsNullOrEmpty(myWWW.error)){
            //	DBManager.username = usernameField.text;
            //	DBManager.money = int.Parse(www.text.Split('\t')[1]);

            jsonData = JsonUtility.ToJson(myWWW.text);

            resp myObject = JsonUtility.FromJson<resp>(jsonData);

            resp tangina = new resp();

            Debug.Log(jsonData);
        }

	}


    [Serializable]
    public class resp
    {
        public string connection;
        public int userID;
    }

    // public void verifyInputs(){
    // 	submitButton.interactable = (nameField.text.lenth)
    // }

}
