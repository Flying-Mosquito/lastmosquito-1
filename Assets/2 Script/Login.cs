﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour {
    #region Variables
    //Static Variables
    public static string ID = "";
    public static string Password = "";
    public static string NickName = "";
    //Public Variables
    public string CurrentMenu = "Login";
    //Private Variables
    private string CreateAccountUrl = "";
   // private string LoginUrl = "";
    private string ConfrimPass = "";
    private string ConfirmEmail = "";
    private string CID = "";
    private string Cpassword = "";

    //GUI Test section

    public float X;
    public float Y;
    public float Width;
    public float Height;
    public float control = 60;
    #endregion 
    // Use this for initialization
    void Start () {
	
	}
    void OnGUI()
    {

        if(CurrentMenu =="Login")
        {
            LoginGUI();
        }else if(CurrentMenu == "CreateAccount")
        {
            CreateAccountGUI();
        }

    }

    #region Custom methods

    void LoginGUI()
    {
        GUI.Box(new Rect(280-control*2, 120 - control, (Screen.width/4)+ 200,(Screen.height/4)+ 250),"Login");

        if(GUI.Button(new Rect(360 - control*2, 360 - control, 120,25),"Create Account"))
        {
            CurrentMenu = "CreateAccount";
        }


        if (GUI.Button(new Rect(520 - control*2, 360 - control, 120, 25), "Log in"))
        {
        Application.LoadLevel(13);

        }
        GUI.Label(new Rect(300 - control*2, 200 - control, 220, 25), "ID");
        ID = GUI.TextField(new Rect(390 - control*2, 225 - control, 220,25), ID);

        GUI.Label(new Rect(300 - control*2, 250 - control, 220, 25), "Password");
        Password = GUI.TextField(new Rect(390 - control*2, 275 - control, 220, 25), Password);

     

    }
    public void Click()
    {

        if (GUI.Button(new Rect(520 - control*2, 360 - control, 120, 25), "Log in"))
        {
            SceneManager.LoadScene(1);

        }
       
    }
    void CreateAccountGUI() {
        GUI.Box(new Rect(280 - control*2, 120 - control, (Screen.width / 4) + 200, (Screen.height / 4) + 250), "Create Account");

     
        GUI.Label(new Rect(370 - control*2, 200 - control, 220, 25), "ID");
        CID = GUI.TextField(new Rect(390 - control * 2, 225 - control, 220, 25), CID);

        GUI.Label(new Rect(370 - control * 2, 250 - control, 220, 25), "Password");
        Cpassword = GUI.TextField(new Rect(390 - control * 2, 275 - control, 220, 25), Cpassword);

        GUI.Label(new Rect(300 - control * 2, 200 - control, 220, 25), "NickName");
        NickName = GUI.TextField(new Rect(390 - control * 2, 300 - control, 220, 25), NickName);

        GUI.Label(new Rect(370 - control * 2, 320 - control, 220, 25), "Confirm Email");
        ConfirmEmail = GUI.TextField(new Rect(390 - control * 2, 350 - control, 220, 25), ConfirmEmail);

        GUI.Label(new Rect(370 - control * 2, 370 - control, 220, 25), "Confirm Password");
       ConfrimPass = GUI.TextField(new Rect(390 - control * 2, 410 - control, 220, 25), ConfrimPass);


        if (GUI.Button(new Rect(360 - control * 2, 460 - control, 120, 25), "Create Account"))
        {
            if (ConfrimPass == Cpassword && ConfirmEmail == CID) {
                StartCoroutine("Create Account");
            }
            else
            {
                StartCoroutine("Create Account");
            }
        }
        if (GUI.Button(new Rect(520 - control*2, 460 - control, 120, 25), "Back"))
        {
            CurrentMenu = "Login";

        }
    }
  
    #endregion

    #region CoRoutines
    //IEnumerator CreateAccount()
    //{
    //    WWWForm Form = new WWWForm();
    //    Form.AddField("Email", CEmail);
    //    Form.AddField("Password", Cpassword);

    //    WWW CreateAcountWWW = new WWW(CreateAccountUrl, Form);

    //    yield return CreateAcountWWW;
    //    if(CreateAcountWWW.error != null)
    //    {
    //        Debug.LogError("Cannot Connect to Account Creation");

    //    }else
    //    {
    //        string CreateAccountReturn = CreateAcountWWW.text;
    //        if(CreateAccountReturn == "Success")
    //        {
    //            Debug.Log("Success : Account Created");
    //            CurrentMenu = "Login";

    //        }
    //    }
    //}
    #endregion
}
