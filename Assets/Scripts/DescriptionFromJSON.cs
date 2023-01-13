using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Linq;
using TMPro;

[System.Serializable]
public class DescriptionFromJSON
{
    public string nameOfRoleOrSkill;
    public string descriptionOfRoleOrSkill;
}

[System.Serializable]
public class DescriptionFromJSONList
{
    public List<DescriptionFromJSON> descriptionFromJSONList;
}
