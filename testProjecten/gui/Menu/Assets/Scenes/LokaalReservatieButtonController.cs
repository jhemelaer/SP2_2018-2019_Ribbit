using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LokaalReservatieButtonController : MonoBehaviour {

   
       
public void goToLokaalReservatie()
    {
        SceneManager.LoadScene("LokaalReservatieScene");
    }
}
