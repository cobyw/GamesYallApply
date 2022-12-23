using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//script sourced from https://www.youtube.com/watch?v=2-tUwIQmBNE&ab_channel=1MinUnityTutorials

public class Survey : MonoBehaviour
{
    //the various fields to be sent to google
    [SerializeField] InputField nameField;
    [SerializeField] InputField emailField;
    [SerializeField] InputField skillsField;
    [SerializeField] InputField rolesField;
    [SerializeField] InputField startField;
    [SerializeField] InputField marginilizedField;
    [SerializeField] InputField infoField;

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
        form.AddField("entry.835373714", nameField.text);
        form.AddField("entry.945299585", emailField.text);
        form.AddField("entry.1850660995", skillsField.text);
        form.AddField("entry.791478637", rolesField.text);
        form.AddField("entry.1845715159", startField.text);
        form.AddField("entry.504075193", marginilizedField.text);
        form.AddField("entry.1463815909", infoField.text);


        //create the web request
        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        //send the request when completed
        yield return www.SendWebRequest();
    }


}