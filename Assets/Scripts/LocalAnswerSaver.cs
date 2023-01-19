using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;

public class LocalAnswerSaver : MonoBehaviour
{
    [SerializeField] FormAnswers formAnswers;
    public void SaveLocalAnswer()
    {
        var outputPath = Path.Combine(Application.persistentDataPath, formAnswers.nameField + ".txt");

        string concat = formAnswers.nameField + ";";
        concat += formAnswers.email + ";";
        concat += formAnswers.skills + ";";
        concat += formAnswers.roles + ";";
        concat += formAnswers.startDate + ";";
        concat += formAnswers.marginilized + ";";
        concat += formAnswers.additionalInfo;

        File.WriteAllText(outputPath, concat);
    }

    public void SaveLocalAnswerJsonCombined()
    {
        string fileName = string.Format("LocalAnswers.json");
        string jsonPath = Path.Combine(Application.persistentDataPath, fileName);

        string inputString = "";

        if (File.Exists(jsonPath))
        {

            inputString = File.ReadAllText(jsonPath);
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

        File.WriteAllText(jsonPath, inputString);
    }
}
