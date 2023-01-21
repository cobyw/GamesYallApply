using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;


public class LocalAnswerSaver : MonoBehaviour
{
    [SerializeField] FormAnswers formAnswers;

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
    }
}
