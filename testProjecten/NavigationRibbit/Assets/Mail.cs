//Bron: https://www.youtube.com/watch?v=qRytzVzruCQ

using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mail : MonoBehaviour
{
    public InputField lokaal;
    public string rol;
    public string naamGebruiker;
    public string aangevraagdLokaal;

    public void sendmail_start()
    {
        StartCoroutine(sendmail()); // A coroutine makes it possible for a function to execute over multiple frames. In fact, a coroutine stops the execution of the code and temporarily gives back control to Unity.
    }

    public IEnumerator sendmail()
    {
        yield return new WaitForSeconds(0.0f);

        if (Persoon.naam == "" || Persoon.naam == null || Persoon.typeUser == Type.NIET_INGELOGD)
        {
            SceneManager.LoadScene("LoginScene");
        }

        if (Persoon.naam != "" && Persoon.naam != null && Persoon.typeUser != Type.NIET_INGELOGD)
        {
            naamGebruiker = Persoon.naam;
            rol = Persoon.typeUser.ToString();

            if (lokaal.text != "" && lokaal.text != null)
            {
                aangevraagdLokaal = lokaal.text;
            }

            // The next part of code sends us an e-mail

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("test@demo.com");
            mail.To.Add("ribbitsoftwareproject@gmail.com");
            mail.Subject = "Aanvraag lokaalreservatie " + aangevraagdLokaal;
            mail.Body = rol + " " + naamGebruiker + " heeft gevraagd om lokaal " + aangevraagdLokaal + " te reserveren.";
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("ribbitsoftwareproject@gmail.com", "ribbit2018") as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtpServer.Send(mail);
        }
    }

    public void onClick()
    {
        SceneManager.LoadScene("MenuStudentScene");
    }
}