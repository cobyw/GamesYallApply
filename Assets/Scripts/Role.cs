using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Role", menuName = "ScriptableObjects/Role Scriptable Object", order = 2)]
public class Role : ScriptableObject
{
    [SerializeField] private string nameOfRole;
    [SerializeField, TextArea(10, 25)] private string descriptionOfRole;
    [SerializeField] private List<Skill> requiredSkills;

    public string NameOfRole
    {
        get => nameOfRole;
    }

    public List<Skill> RequiredSkills
    {
        get => requiredSkills;
    }

    public string DescriptionOfRole
    {
        get => descriptionOfRole;
        set => descriptionOfRole = value;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        nameOfRole = name;
    }
#endif
}
