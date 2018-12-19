using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

//https://www.youtube.com/watch?v=FChVgb6EXGk&t=133s

public class WWWFormTest : MonoBehaviour {
    public void Start()
    {
        StartCoroutine(Upload());  
    }


    IEnumerator Upload()
    {
        //create data or form
        WWWForm form = new WWWForm();
        //add fields
        form.AddField("username", "hasan.zamin@student.ehb.be");
        form.AddField("password", "dNXcpYy8");
        //create object for POST in unity
        UnityWebRequest www = UnityWebRequest.Post("https://cas.ehb.be/login", form);

        yield return www.Send();
        //catch errors
        if (www.isError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload successfull");
        }

    }
    // navigatie naar rooster.ehb.be

    public void StartRooster()
    {
        WWW Nav = new WWW("https://rooster.ehb.be/Scientia/SWS/SYL_PRD_1819/");
        StartCoroutine(WaitforRequest(Nav));
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



}
