using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skills Scriptable Object", order = 1)]
public class Skills : ScriptableObject
{
    [SerializeField] private string nameOfSkill;
    [SerializeField, TextArea(15, 20)] private string descriptionOfSkill;

    private void OnValidate()
    {
        nameOfSkill = name;
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
    }
}
