//Bronnen:
// https://www.youtube.com/watch?v=vFs0_skd0E4
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour {
    public GameObject gebruikersnaam;
    public GameObject wachwtoord;
    private string Gebruikersnaam;
    private string Wachtwoord;
    private string form;

	// Use this for initialization
	void Start () {
		
	}

    public void LoginKnop()
    {
        Debug.Log("Login knop ingedrukt");
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(gebruikersnaam.GetComponent<InputField>().isFocused)
            {
                wachwtoord.GetComponent<InputField>().Select();
            }
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(Gebruikersnaam != "" && Wachtwoord != "")
            {
                LoginKnop();
            }
        }
        Gebruikersnaam = gebruikersnaam.GetComponent<InputField>().text;
        Wachtwoord = wachwtoord.GetComponent<InputField>().text;
	}
}
