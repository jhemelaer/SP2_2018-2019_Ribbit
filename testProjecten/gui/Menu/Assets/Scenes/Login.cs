//Bronnen:
// https://www.youtube.com/watch?v=vFs0_skd0E4
// https://www.youtube.com/watch?v=FBo9OdEF_D4
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        bool GN = false;
        bool WW = false;

        if(Gebruikersnaam == "Jef") // Als de gebruikersnaam voorkomt in de Active Directory. Moet nog geïmplementeerd worden.
        {
            GN = true;
        }
        else
        {
            Debug.LogWarning("Deze gebruikersnaam kont niet voor in ons systeem");
        }

        if(Wachtwoord != "")
        {
            if(Wachtwoord == "Jefzijnwachtwoord") // Moet nog geïmplementerd worden.
            {
                WW = true;
            }
            else
            {
                Debug.LogWarning("Deze combinatie van gebruikersnnaam en wachtwoord is niet correct");
            }
        }

        if(GN == true && WW == true)
        {
            Debug.LogWarning("U bent ingelogd");
			//redirect naar studentenmenu
            SceneManager.LoadScene("MenuStudentScene");
        }
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
