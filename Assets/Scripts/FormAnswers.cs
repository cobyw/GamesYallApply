using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum AnswerType
{
    nameField,
    email,
    skills,
    roles,
    startDate,
    marginilized,
    additionalInfo,
}

[CreateAssetMenu(fileName = "Form Answer", menuName = "ScriptableObjects/Form Answer Scriptable Object", order = 3)]

public class FormAnswers : ScriptableObject
{
    public string nameField;
    public string email;
    public string skills;
    public string roles;
    public string startDate;
    public string marginilized;
    public string additionalInfo;
}
