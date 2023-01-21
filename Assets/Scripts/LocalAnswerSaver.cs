using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

public class LocalAnswerSaver : MonoBehaviour
{
    [SerializeField] FormAnswers formAnswers;

#if UNITY_WEBGL
    //sourced from https://pixeleuphoria.com/blog/index.php/2020/04/27/unity-webgl-download-content/
    [DllImport("__Internal")]
    public static extern void BrowserTextDownload(string filename, string textContent);
#endif

    public void SaveAnswersAsPlayerPrefs()
    {
        string inputString = "";

        if (PlayerPrefs.HasKey("SaveData"))
        {

            inputString = PlayerPrefs.GetString("SaveData");
            inputString += "\n";
        }

        SerializableFormAnswers serializableFormAnswers = new SerializableFormAnswers();

        serializableFormAnswers.nameField = formAnswers.nameField;
        serializableFormAnswers.email = formAnswers.email;
        serializableFormAnswers.skills = formAnswers.skills;
        serializableFormAnswers.roles = formAnswers.roles;
        serializableFormAnswers.startDate = formAnswers.startDate;
        serializableFormAnswers.marginilized = formAnswers.marginilized;
        serializableFormAnswers.additionalInfo = formAnswers.additionalInfo;

        var jsonToSaveConverted = JsonConvert.SerializeObject(serializableFormAnswers);

        inputString += jsonToSaveConverted;

        PlayerPrefs.SetString("SaveData", inputString);
#if UNITY_WEBGL
        BrowserTextDownload("ApplicantData.json", inputString);
        Debug.LogFormat("Wrote {0} to downloaded file", inputString);
#else
        DirectoryInfo info = Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\GamesYall");
        System.IO.File.WriteAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)+ "\\GamesYall\\ApplicantData.json", inputString);
        Debug.LogFormat("Wrote {0} to disk", inputString);
#endif
    }
}
