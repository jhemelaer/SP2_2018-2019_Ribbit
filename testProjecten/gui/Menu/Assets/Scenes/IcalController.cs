using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//videoplayer source: https://docs.unity3d.com/ScriptReference/Video.VideoPlayer.html
public class IcalController : MonoBehaviour {
    //this function will open your personal timetable on desiderius
	public void OpenDesiderius () {
        Application.OpenURL("https://desiderius.ehb.be/index.php?application=Ehb%5CApplication%5CCalendar%5CExtension%5CSyllabusPlus&syllabus_action=UserBrowser");
    }


//this function will open the video to set the ical file 	
	public void StartVideo () {
        Application.OpenURL("https://youtu.be/KqCFhz_p9Rk");
    }
    

}
