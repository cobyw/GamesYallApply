using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DescriptionFromJSON
{
    public string nameOfRoleOrSkill;
    [TextArea] public string descriptionOfRoleOrSkill;
}

[System.Serializable]
public class DescriptionFromJSONList
{
    public List<DescriptionFromJSON> descriptionFromJSONList;
}
