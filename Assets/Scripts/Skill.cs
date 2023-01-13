using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skills Scriptable Object", order = 1)]
public class Skill : ScriptableObject
{
    [SerializeField] private string nameOfSkill;
    [SerializeField, TextArea(15, 20)] private string descriptionOfSkill;
    [SerializeField] private bool requiredSkill = false;

    [SerializeField] private bool hasSkill = false;
    private bool skillAssigned = false;

    public bool HasSkill
    {
        get => hasSkill;

        set
        {
            hasSkill = value;
        }
    }
    public bool SkillAssigned
    {
        get => skillAssigned;

        set
        {
            skillAssigned = value;
        }
    }

    public bool RequiredSkill {
        get => requiredSkill;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!Application.isPlaying)
        {
            Init();
        }
    }
#endif

    public void Init()
    {
        nameOfSkill = name;
        HasSkill = false;
        SkillAssigned = false;
    }

    public string NameOfSkill
    {
        get
        {
            return nameOfSkill;
        }
    }
    public string DescriptionOfSkill
    {
        get
        {
            return descriptionOfSkill;
        }
        set
        {
            descriptionOfSkill = value;
        }
    }
}
