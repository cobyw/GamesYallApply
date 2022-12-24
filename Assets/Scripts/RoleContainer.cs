using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoleContainer : MonoBehaviour
{

    [SerializeField] private List<Role> allRoleObjects;
    [SerializeField] private string originalSkillListString = "Your Desired Roles:\n";
    [SerializeField] private string addSkillsString = "You qualify for these roles! Add roles you are interested in to the blue box!";
    private string skillList = "Your Desired Roles:";

    [SerializeField] private List<Role> applicableRoleObjects;

    private void OnValidate()
    {
        allRoleObjects = Resources.LoadAll<Role>("").ToList();
    }

    public void CheckRoles()
    {
        applicableRoleObjects = new List<Role>();

        foreach (Role currentRole in allRoleObjects)
        {
            //we assume people can do it by default
            bool meetsRequirements = true;

            //we then go through each requried skill for the role
            foreach (Skill requiredSkill in currentRole.RequiredSkills)
            {
                //if they fail to meet any skill they no longer meet the requirements
                if (!requiredSkill.HasSkill)
                {
                    meetsRequirements = false;
                }
            }

            //at this point if they still meet the requirement they are good to go
            if (meetsRequirements)
            {
                applicableRoleObjects.Add(currentRole);
            }
        }
    }
}
