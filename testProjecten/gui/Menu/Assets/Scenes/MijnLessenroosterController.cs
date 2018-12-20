using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MijnLessenroosterController : MonoBehaviour {
    //this code navigates to the the ical download and tutorial
     public void GoToIcal() {
        SceneManager.LoadScene("OpenIcalScene");
        }

	
}
