using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcalController : MonoBehaviour {
    //this function will open your personal timetable on desiderius
	public void OpenDesiderius () {
        Application.OpenURL("https://desiderius.ehb.be/index.php?application=Ehb%5CApplication%5CCalendar%5CExtension%5CSyllabusPlus&syllabus_action=UserBrowser");
    }


//this function will open the calender on the device 	
	public void OpenCalender () {
		
	}
}
