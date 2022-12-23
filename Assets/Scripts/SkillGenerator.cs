using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillGenerator : MonoBehaviour
{
    private List<Skill> skillsToGenerate;
    public SkillObject prefabForSkills;

    private SkillObject currentSkill;

    private int currentSkillIndex = 0;

    [SerializeField]
    private SkillContainer skillContainer;

    private void Start()
    {
        if (skillContainer == null)
        {
            skillContainer = FindObjectOfType<SkillContainer>();
        }

        skillsToGenerate = skillContainer.SkillObjectList;

        currentSkillIndex = 0;

        GenerateSkill();
    }

    public void GenerateSkill()
    {
        currentSkill = null;
        currentSkill = Instantiate(prefabForSkills, transform);
        currentSkill.Skill = skillsToGenerate[currentSkillIndex];

        currentSkillIndex ++;

        //if (currentSkillIndex >= skillsToGenerate.Count)
        //{
        //    currentSkillIndex = 0;
        //}
    }

    public void Undo()
    {
        if (currentSkill != null)
        {
            Destroy(currentSkill.gameObject);
        }

        currentSkillIndex-=2;

        //if (currentSkillIndex < 0)
        //{
        //    currentSkillIndex = skillsToGenerate.Count - 1;
        //}

        skillContainer.RemoveSkill(skillsToGenerate[currentSkillIndex]);
    }
}
