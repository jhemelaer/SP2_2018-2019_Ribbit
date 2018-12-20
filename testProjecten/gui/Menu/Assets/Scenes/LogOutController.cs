using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogOutController : MonoBehaviour
{

    // Use this for initialization
    public void logOut() // The stored user data is removed.
    {
        Persoon.naam = "";
        Persoon.typeUser = Type.NIET_INGELOGD;

        SceneManager.LoadScene("LoginScene");
    }
}
