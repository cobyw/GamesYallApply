using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Linq;
using TMPro;

[RequireComponent(typeof(AnswerSaver))]
public class SkillContainer : MonoBehaviour
{
    [SerializeField] private List<Skill> skillObjectList;
    [SerializeField] private string originalSkillListString = "Your Skills:\n";
    [SerializeField, TextArea(5, 25)] private string addSkillsString = "Add your skills to the blue box!";
    private string skillList = "Your Skills:";

    private int numSkillsAssigned = 0;
    private int numSkillsHad = 0;

    //cached references
    [SerializeField]
    private SkillGenerator skillGenerator;
    [SerializeField]
    private GameObject undoButton;
    [SerializeField]
    private TextMeshProUGUI skillListTextBox;
    [SerializeField]
    private GameObject allSkillsSelectedUI;
    
    [SerializeField]
    private AnswerSaver answerSaver;

    public ref List<Skill> SkillObjectList
    {
        get => ref skillObjectList;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        skillObjectList = Resources.LoadAll<Skill>("").ToList();
        foreach (Skill currentSkill in skillObjectList)
        {
            currentSkill.Init();
        }
    }
#endif

    private void Start()
    {
        skillObjectList = Resources.LoadAll<Skill>("").ToList();
        foreach (Skill currentSkill in skillObjectList)
        {
            currentSkill.Init();
        }

        if (skillGenerator == null)
        {
            skillGenerator = FindObjectOfType<SkillGenerator>();
        }

        if (answerSaver == null)
        {
            answerSaver = GetComponent<AnswerSaver>();
        }

        if (undoButton == null)
        {
            Debug.LogError("no reference to undo button set in " + this);
        }

        undoButton.SetActive(false);

        skillList = addSkillsString;
        skillListTextBox.text = skillList;
    }

    //assigns the skill as either had or not
    public void AssignSkill(bool goodSkill, Skill skill)
    {
        if (skill.SkillAssigned == false)
        {
            skill.HasSkill = goodSkill;
            skill.SkillAssigned = true;

            AdjustSkillList();
        }
    }

    //removes the skill from the list and marks it as not yet assigned
    public void RemoveSkill(Skill skill)
    {
        skill.HasSkill = false;
        skill.SkillAssigned = false;

        AdjustSkillList();
    }

    private void AdjustSkillList()
    {

        skillList = originalSkillListString;
        numSkillsAssigned = 0;
        numSkillsHad = 0;

        foreach (Skill currentSkill in skillObjectList)
        {
            if (currentSkill.SkillAssigned)
            {
                numSkillsAssigned++;
            }

            if (currentSkill.HasSkill)
            {
                skillList = (skillList + "\n" + currentSkill.NameOfSkill);
                skillListTextBox.text = skillList;
                numSkillsHad++;
            }
        }

        //activate the undo button if we have assigned any skills
        undoButton.SetActive(numSkillsAssigned >= 1);

        //if we have no skills 
        if (numSkillsAssigned == 0 || numSkillsHad == 0)
        {
            skillList = addSkillsString;
            skillListTextBox.text = skillList;
        }

        //if we have not set every skill generate the next skill.
        if (numSkillsAssigned < skillObjectList.Count)
        {
            skillGenerator.GenerateSkill();
            allSkillsSelectedUI.SetActive(false);
        }
        else
        {
            skillGenerator.AddFinalSkill();
            allSkillsSelectedUI.SetActive(true);
            SaveSkills();
        }
    }

    private void SaveSkills()
    {
        string tempString = string.Empty;
        foreach (Skill currentSkill in skillObjectList)
        {
            if (currentSkill.HasSkill)
            {
                tempString += currentSkill.NameOfSkill + ',';
            }
        }

        answerSaver.saveAnswer(tempString);
    }
}
