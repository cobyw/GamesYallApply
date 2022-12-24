using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSaver : MonoBehaviour
{
    [SerializeField] private FormAnswers formAnswers;
    [SerializeField] private AnswerType answerType;

    public void saveAnswer(string answerToSave)
    {
        if (formAnswers == null)
        {
            Resources.Load<FormAnswers>("");
        }

        switch (answerType)
        {
            case AnswerType.nameField:
                formAnswers.nameField = answerToSave;
                break;
            case AnswerType.email:
                formAnswers.email = answerToSave;
                break;
            case AnswerType.skills:
                formAnswers.skills = answerToSave;
                break;
            case AnswerType.roles:
                formAnswers.roles = answerToSave;
                break;
            case AnswerType.startDate:
                formAnswers.startDate = answerToSave;
                break;
            case AnswerType.marginilized:
                formAnswers.marginilized = answerToSave;
                break;
            case AnswerType.additionalInfo:
                formAnswers.additionalInfo = answerToSave;
                break;
        }
    }
}
