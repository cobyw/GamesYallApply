using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnswers : MonoBehaviour
{
    [SerializeField] private FormAnswers formAnswers;
    [SerializeField] private bool resetOnStart = true;
    // Start is called before the first frame update
    void Start()
    {
        if (resetOnStart)
        {
            formAnswers.nameField = string.Empty;
            formAnswers.email = string.Empty;
            formAnswers.skills = string.Empty;
            formAnswers.roles = string.Empty;
            formAnswers.startDate = string.Empty;
            formAnswers.marginilized = string.Empty;
            formAnswers.additionalInfo = string.Empty;
        }
    }
}
