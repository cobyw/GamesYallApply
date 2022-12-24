using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Role", menuName = "ScriptableObjects/Role Scriptable Object", order = 2)]
public class Role : ScriptableObject
{
    [SerializeField] private string nameOfRoll;
    [SerializeField, TextArea(10,25)] private string descriptionOfRole;
    [SerializeField] private List<Skill> requiredSkills;

    public List<Skill> RequiredSkills
    {
        get => requiredSkills;
    }

    private void OnValidate()
    {
        nameOfRoll = name;
    }
}
