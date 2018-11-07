//Bron: https://www.youtube.com/watch?v=qRytzVzruCQ

using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Mail : MonoBehaviour {

    public InputField naam;
    public InputField lokaal;

    public void sendmail_start()
    {
        StartCoroutine(sendmail());
    }

    public IEnumerator sendmail()
    {
        yield return new WaitForSeconds(0.0f);
        if(naam.text != "" && lokaal.text != "")
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("test@demo.com");
            mail.To.Add("ribbitsoftwareproject@gmail.com");
            mail.Subject = "Aanvraag lokaalreservatie " + lokaal.text;
            mail.Body = naam.text + " heeft gevraagd om lokaal " + lokaal.text + " te reserveren.";
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("ribbitsoftwareproject@gmail.com", "ribbit2018") as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtpServer.Send(mail);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
