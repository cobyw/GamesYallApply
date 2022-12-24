using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBrain : MonoBehaviour
{
    private int currentTicks = 0;
    private int totalTicks = 1;

    private float currentPercent = 0;

    [SerializeField] int minSavesFilledIn;
    [SerializeField] int maxSavesFilledIn;

    [SerializeField] private Slider slider;
    [SerializeField] private FormAnswers formAnswers;


    private static SliderBrain _instance;

    public static SliderBrain Instance
    {
        get
        {
            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        if (maxSavesFilledIn != 0)
        {
            totalTicks = maxSavesFilledIn - minSavesFilledIn;
        }
    }

    public void CheckSavedAnswers()
    {
        int answersSaved = 0;

        if (formAnswers.nameField != string.Empty)
        {
            answersSaved++;
        }
        if (formAnswers.email != string.Empty)
        {
            answersSaved++;
        }
        if (formAnswers.skills != string.Empty)
        {
            answersSaved++;
        }
        if (formAnswers.roles != string.Empty)
        {
            answersSaved++;
        }
        if (formAnswers.startDate != string.Empty)
        {
            answersSaved++;
        }
        if (formAnswers.marginilized != string.Empty)
        {
            answersSaved++;
        }
        if (formAnswers.additionalInfo != string.Empty)
        {
            answersSaved++;
        }


        currentTicks = answersSaved - minSavesFilledIn;
        currentPercent = (float)currentTicks / (float)totalTicks;

        slider.value = currentPercent;
    }

    public void UpdateSlider(int current, int total)
    {
        currentTicks = current;
        totalTicks = total;

        currentPercent = (float)currentTicks / (float)totalTicks;

        slider.value = currentPercent;
    }
}
