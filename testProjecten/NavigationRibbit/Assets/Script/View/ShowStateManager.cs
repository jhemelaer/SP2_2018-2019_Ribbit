using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStateManager : MonoBehaviour {

	public GameObject actionBar;
	Image actionBarImg;
	Text appNameText;
	private ToastMessageScript toastMessageScript;
	private enum StateColor
	{
		Idle,
		Navigate
	}

	// Use this for initialization
	void Start () {
		toastMessageScript = gameObject.GetComponent<ToastMessageScript>();
		actionBarImg = actionBar.GetComponent<Image>();
		appNameText = actionBar.gameObject.transform.Find("AppName").gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//recive from MainController, may be implement from callback
	public void OnBeginPointChange(GameObject bpoint)// shows message to user when BeginPoint is found
    {
        GameObject dpoint = MainController.instance.destinationPoint;
        GameObject rpoint = MainController.instance.reachedPoint;
		string dp = "null";
        string rp = "null";
		string mesge = "---";
        if (dpoint == null && rpoint == null)
        {
            mesge = "You are at: " + bpoint.GetComponent<MarkerData>().roomName + " You are now able to select a destination.";
            ChangeActionText("at:" + bpoint.GetComponent<MarkerData>().roomName);
        }
        else if (dpoint != null && rpoint == null)
        {
            dp = dpoint.GetComponent<MarkerData>().roomName;
            mesge = "You are now at: " + bpoint.GetComponent<MarkerData>().roomName;
            ChangeActionText("Go to:" + dpoint.GetComponent<MarkerData>().roomName);

        }
        else if (dpoint == null && rpoint != null)
        {
            rp = rpoint.GetComponent<MarkerData>().roomName;
            if (bpoint.GetComponent<MarkerData>().roomName == rpoint.GetComponent<MarkerData>().roomName)
            {
                mesge = "Arrived at the destination " + bpoint.GetComponent<MarkerData>().roomName;
                ChangeActionText("Arrived:" + bpoint.GetComponent<MarkerData>().roomName);
            }
            else
            {
                mesge = "You are now at: " + bpoint.GetComponent<MarkerData>().roomName;
                ChangeActionText("at:" + bpoint.GetComponent<MarkerData>().roomName);
            }
        }
        else if (dpoint != null && rpoint != null)
        {
            dp = dpoint.GetComponent<MarkerData>().roomName;
            rp = rpoint.GetComponent<MarkerData>().roomName;
            if (bpoint.GetComponent<MarkerData>().roomName == rpoint.GetComponent<MarkerData>().roomName)
            {
                mesge = "You are now at: " + bpoint.GetComponent<MarkerData>().roomName;
                ChangeActionText("Go to:" + dpoint.GetComponent<MarkerData>().roomName);
            }
            else
            {
                mesge = "You are now at: " + bpoint.GetComponent<MarkerData>().roomName;
                ChangeActionText("at:" + dpoint.GetComponent<MarkerData>().roomName);
            }
        }
        Debug.Log(mesge + "  |  Begin Change - State:" + MainController.instance.appState + "  |  "
        + "dest: " + dp + "  reach: " + rp);
        toastMessageScript.showToastOnUiThread(mesge, true);
        ChangeActionBarColor(MainController.instance.appState == MainController.AppState.Idle ? StateColor.Idle : StateColor.Navigate);
    }

    public void OnDestinationPointChange(GameObject dpoint)// shows message to user when destinationPoint is chosen
    {
        GameObject bpoint = MainController.instance.beginPoint;
        GameObject rpoint = MainController.instance.reachedPoint;
		string bp = "null";
        string rp = "null";
		string mesge = "---";
        if (dpoint == null)
        {
            mesge = "Navigation canceled";
            ChangeActionText("Ribbit");
        }
        else if (bpoint == null && dpoint != null && rpoint == null)
        {
            mesge = "Chosen destination: " + dpoint.GetComponent<MarkerData>().roomName + "\n Please walk around To identify your location";
            ChangeActionText("Searching for location");
            toastMessageScript.showToastOnUiThread(mesge, true);
        }
        else if (bpoint != null && dpoint != null && rpoint == null)
        {
            bp = bpoint.GetComponent<MarkerData>().roomName;
            mesge = "Start navigating to: " + dpoint.GetComponent<MarkerData>().roomName + " already";
            ChangeActionText("Go to:" + dpoint.GetComponent<MarkerData>().roomName);
        }
        else if (bpoint == null && dpoint != null && rpoint != null)
        {
            rp = rpoint.GetComponent<MarkerData>().roomName;
            mesge = "Start navigating to?" + dpoint.GetComponent<MarkerData>().roomName + " already";
            ChangeActionText("Still:" + dpoint.GetComponent<MarkerData>().roomName);

        }
        else if (bpoint != null && dpoint != null && rpoint != null)
        {
            bp = bpoint.GetComponent<MarkerData>().roomName;
            rp = rpoint.GetComponent<MarkerData>().roomName;
            if (bpoint.GetComponent<MarkerData>().roomName == dpoint.GetComponent<MarkerData>().roomName)
            {
                mesge = "You are already at your destination. Please chose an other destination: " + dpoint.GetComponent<MarkerData>().roomName;
            }
            else if (dpoint.GetComponent<MarkerData>().roomName == rpoint.GetComponent<MarkerData>().roomName)
            {
                mesge = "Start navigating to: " + dpoint.GetComponent<MarkerData>().roomName + "already";
                ChangeActionText("Go to:" + dpoint.GetComponent<MarkerData>().roomName);
            }
            else
            {
                mesge = "Start navigating to: " + dpoint.GetComponent<MarkerData>().roomName + " already";
                ChangeActionText("Go to:" + dpoint.GetComponent<MarkerData>().roomName);
            }
        }
        Debug.Log(mesge + "  |  Dest Change - State:" + MainController.instance.appState + "  |  "
        + "begin: " + bp + "  reach: " + rp);
        toastMessageScript.showToastOnUiThread(mesge, true);
        ChangeActionBarColor(MainController.instance.appState == MainController.AppState.Idle ? StateColor.Idle : StateColor.Navigate);
    }

    private void ChangeActionBarColor(StateColor color)
	{
		switch (color)
        {
            case StateColor.Idle:
                actionBar.GetComponent<Image>().color = new Color32(60, 126, 255, 255);
                break;
            case StateColor.Navigate:
                actionBar.GetComponent<Image>().color = new Color32(126, 60, 255, 255);
                break;
            default: actionBar.GetComponent<Image>().color = new Color32(60, 126, 255, 255); break;
        }
	}

	private void ChangeActionText(string actext)
    {
        appNameText.text = actext;
    }
}
