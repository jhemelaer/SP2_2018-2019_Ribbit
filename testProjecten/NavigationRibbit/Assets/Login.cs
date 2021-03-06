﻿//Bronnen:
// https://www.youtube.com/watch?v=vFs0_skd0E4
// https://www.youtube.com/watch?v=FBo9OdEF_D4
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour
{
    public GameObject gebruikersnaam;
    public GameObject wachwtoord;
    private string Gebruikersnaam;
    private string Wachtwoord;
    private string form;
    private Dictionary<string, string> studentenGegevens = new Dictionary<string, string>();
    private Dictionary<string, string> docentenGegevens = new Dictionary<string, string>();

    // Use this for initialization
    void Start()
    {

    }

    public void LoginKnop()
    {

        /* Both dictionaries contain credentials for students and teachers.
         * Originally, we would work with an Active Directory containing the credentials, but there were some problems with that.
         * Please read the documents to get the full explenation. */

        studentenGegevens.Add("malke.boulanger", "Puc55!");
        studentenGegevens.Add("kKarle.claretha", "Avi15!");
        studentenGegevens.Add("jeraldine.omara", "Juq59!");
        studentenGegevens.Add("krista.vreeland", "Jas08!");

        docentenGegevens.Add("rein.swager", "Ewa35!");
        docentenGegevens.Add("raza.mets", "Eke14!");
        docentenGegevens.Add("ona.dejonge", "Lxu54!");

        foreach (KeyValuePair<string, string> entry in studentenGegevens)
        {
            if (entry.Key == Gebruikersnaam && entry.Value == Wachtwoord) // If the credentials correspond to the stored credentials.
            {
                Persoon.naam = entry.Key;
                Persoon.typeUser = Type.STUDENT;

                //redirect to studentenmenu
                SceneManager.LoadScene("MenuStudentScene");
            }
        }

        foreach (KeyValuePair<string, string> entry in docentenGegevens)
        {
            if (entry.Key == Gebruikersnaam && entry.Value == Wachtwoord)
            {
                Persoon.naam = entry.Key;
                Persoon.typeUser = Type.DOCENT;

                //redirect to docentenmenu
                SceneManager.LoadScene("MenuDocentScene");
            }
        }
    }

    // Update is called once per frame
    void Update() // Function is used to make the form responsive
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (gebruikersnaam.GetComponent<InputField>().isFocused)
            {
                wachwtoord.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Gebruikersnaam != "" && Wachtwoord != "")
            {
                LoginKnop();
            }
        }
        Gebruikersnaam = gebruikersnaam.GetComponent<InputField>().text;
        Wachtwoord = wachwtoord.GetComponent<InputField>().text;
    }
}
