using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour {
    //toggle buttons
    public Toggle location;
    public Toggle nfc;//
    public Toggle wifi;
    private LocateMeButtonController locateMeButtonController;

    //toggle actions
    public void ActiveLocation()
    {
        if (location.isOn)
        {
    locateMeButtonController.LocateMe_Click();
        }
    }
public void ActiveNFC()
    {
        if (nfc.isOn)
        {
            //nfc
        }
    }
    public void ActiveWifi()
    {
        if (wifi.isOn)
        {
            CheckConnection(); //https://www.unitystuff.com/unity3d-check-internet-connection/
        }
    }

    public void Goback()
    {
        SceneManager.LoadScene("MenuDocentScene");

    }



    void CheckConnection()
    {
        string HtmlText = GetHtmlFromUri("http://google.com");
        if (HtmlText == "")
        {
            //No connection
            Debug.Log("Internet connection NOT available");
        }
        else if (!HtmlText.Contains("schema.org/WebPage"))
        {
            //Redirecting since the beginning of googles html contains that 
            //phrase and it was not found
        }
        else
        {
            //success
            Debug.Log("Internet connection available");
        }
    }
    public string GetHtmlFromUri(string resource)
    {
        string html = string.Empty;
        System.Net.HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
        try
        {
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                if (isSuccess)
                {
                    using (TextReader reader = new StreamReader(resp.GetResponseStream()))
                    {
                        //Limit the below array to below 200. The longer the array is the longer time it will take.                        
                        char[] cs = new char[100];
                        reader.Read(cs, 0, cs.Length);
                        foreach (char ch in cs)
                        {
                            html += ch;
                        }
                    }
                }
            }
        }
        catch
        {
            return "";
        }
        return html;
    }
}
