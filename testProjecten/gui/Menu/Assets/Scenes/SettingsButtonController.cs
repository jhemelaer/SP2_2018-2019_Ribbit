using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SettingsButtonController : MonoBehaviour {

   
    public void goToSettings(string sceneNaam){
        //functie print kan ook gebruikt worden ipv debug.log
        //bron: https://answers.unity.com/questions/1369393/how-to-switch-between-scenes.html
        SceneManager.LoadScene(sceneNaam);

	Debug.Log("ga naar settings");
}

//overige functies mogen er bij

}
