//Bronnen: https://www.youtube.com/watch?v=qRytzVzruCQ,
// https://www.youtube.com/watch?v=Q4NYCSIOamY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class ContactUsController : MonoBehaviour {

    public Dropdown dropdown;
    private List<string> mogelijkheden = new List<string>() { "AR", "App", "Lessenrooster", "Other" };
    private int categorie;
    private string categorieString;
    public InputField bericht;

    public void goBack()
    {
        SceneManager.LoadScene("MenuDocentScene");
    }

    public void sendmail_start()
    {
        StartCoroutine(sendmail());
    }

    public IEnumerator sendmail()
    {
        yield return new WaitForSeconds(0.0f);

        categorie = dropdown.value;
        categorieString = mogelijkheden[categorie];

        if (Persoon.naam == "" || Persoon.naam == null || Persoon.typeUser == Type.NIET_INGELOGD)
        {
            SceneManager.LoadScene("LoginScene");
        }

        if (categorieString != null && categorieString != "" && Persoon.typeUser != Type.NIET_INGELOGD)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("test@demo.com");
            mail.To.Add("ribbitsoftwareproject@gmail.com");
            mail.Subject = "Contactformulier voor categorie " + categorieString;
            mail.Body = Persoon.typeUser + " " + Persoon.naam + " heeft het contactformulier ingevuld voor de categorie " + categorieString + ":\n\n" + bericht.text;
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("ribbitsoftwareproject@gmail.com", "ribbit2018") as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtpServer.Send(mail);
        }
    }
}
