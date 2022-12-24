using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class FormValidator : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] inputFields;
    [SerializeField] private GameObject badEmailUI;
    [SerializeField] private GameObject formsCompletedUI;


    private bool formValid = false;

    private void Start()
    {
        formValid = false;
        inputFields = FindObjectsOfType<TMP_InputField>();

        if (badEmailUI)
        {
            badEmailUI.gameObject.SetActive(false);
        }

        formsCompletedUI.gameObject.SetActive(formValid);
    }

    public void ValidateFields()
    {
        bool allFieldsValid = true;

        foreach (TMP_InputField inputField in inputFields)
        {
            if (string.IsNullOrEmpty(inputField.text))
            {
                //if any field is null or empty we know not all fields are valid
                //we want to keep going through in case there are any bad emails!
                allFieldsValid = false;
            }
            //if we are looking for an email address
            else if (inputField.characterValidation == TMP_InputField.CharacterValidation.EmailAddress)
            {
                //make sure the @ symbol is present and isn't the first or last character.
                bool hasAppropraiteAt = (inputField.text.IndexOf('@') > 0) && (inputField.text.IndexOf('@') < inputField.text.Length - 2);
                if (!hasAppropraiteAt)
                {
                    allFieldsValid = false;
                    badEmailUI.gameObject.SetActive(true);
                }
                else
                {
                    badEmailUI.gameObject.SetActive(false);
                }
            }
        }


        formValid = allFieldsValid;
        formsCompletedUI.gameObject.SetActive(formValid);
    }
}
