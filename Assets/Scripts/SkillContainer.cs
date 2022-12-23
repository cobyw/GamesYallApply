using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class SkillContainer : MonoBehaviour
{
    [SerializeField] private List<Skills> skillsHad;
    [SerializeField] private List<Skills> skillsNotHad;
    [SerializeField, TextArea(15, 20)] private string skillList = "Your Skills:";

    public void AddSkill(bool goodSkill, Skills skill)
    {
        if (!skillsHad.Contains(skill) && !skillsNotHad.Contains(skill))
        {
            if (goodSkill)
            {
                skillsHad.Add(skill);
                skillList = (skillList + "\n" + skill.NameOfSkill);
            }
            else
            {
                skillsNotHad.Add(skill);
            }
        }
    }
}
