using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackController : MonoBehaviour {

   public void goBack()
    {
        if(Persoon.typeUser == Type.NIET_INGELOGD)
        {
            SceneManager.LoadScene("LoginScene");
        }
        else if(Persoon.typeUser == Type.DOCENT)
        {
            SceneManager.LoadScene("MenuDocentScene");
        }
        else if(Persoon.typeUser == Type.STUDENT)
        {
            SceneManager.LoadScene("MenuStudentScene");
        }
    }
}
