using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

//script sourced from https://www.youtube.com/watch?v=2-tUwIQmBNE&ab_channel=1MinUnityTutorials

public class Survey : MonoBehaviour
{
    [SerializeField] FormAnswers formAnswers;

    //the URL of the survey
    private const string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfDJNpD4i9wjwFAN9bUW2uOkHZKhAxrg33g_NcyuBD7pnqgWg/formResponse";


    public void Send()
    {
        StartCoroutine(Post());
    }

    private IEnumerator Post()
    {
        //create the web form
        WWWForm form = new WWWForm();

        //add in entries for each field
        form.AddField("entry.835373714", formAnswers.nameField);
        form.AddField("entry.945299585", formAnswers.email);
        form.AddField("entry.1850660995", formAnswers.skills);
        form.AddField("entry.791478637", formAnswers.roles);
        form.AddField("entry.1845715159", formAnswers.startDate);
        form.AddField("entry.504075193", formAnswers.marginilized);
        form.AddField("entry.1463815909", formAnswers.additionalInfo);


        //create the web request
        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        //send the request when completed
        yield return www.SendWebRequest();
    }


}