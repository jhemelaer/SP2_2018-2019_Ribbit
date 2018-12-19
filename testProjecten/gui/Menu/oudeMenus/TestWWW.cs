using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//bron code : https://answers.unity.com/questions/11021/how-can-i-send-and-receive-data-to-and-from-a-url.html
public class TestWWW : MonoBehaviour {
    //public Text ResponseText;
    public void Start()
    {
        string url = "www.google.be"; //--> om te testen wordt deze url gebruikt
        WWW www = new WWW(url);
        StartCoroutine(WaitforRequest(www));
    }

   public IEnumerator WaitforRequest(WWW www)
    {
        yield return www;
        //check for Errors
        if (www.error == null)
        {
            Debug.Log("WWW OK !!: " + www.text);
         //ResponseText.text = www.text;
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);

        }
    }

  
    public void StartPost()
    {
         string urlPost = "https://cas.ehb.be/login";

        WWWForm form = new WWWForm();
        form.AddField("username","username");
        form.AddField("password", "password");
        WWW www = new WWW(urlPost, form);

        StartCoroutine(WaitforRequestPost(www));
    }
    IEnumerator WaitforRequestPost(WWW www)
    {
        yield return www;
        //check errors
        if (www.error == null)
        {
            Debug.Log("WWW OK: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }


}

