using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class RoleContainer : MonoBehaviour
{
    [SerializeField] private List<Role> allRoleObjects;

    [SerializeField] private List<Role> qualifiedRoles;

#if UNITY_EDITOR
    private void OnValidate()
    {
        allRoleObjects = Resources.LoadAll<Role>("").ToList();
    }
#endif

    public List<Role> QualifiedRoles
    {
        get {
            if (qualifiedRoles.Count == 0)
            {
                CheckRoles();
            }

            return qualifiedRoles;
        }
    }

    private void Start()
    {
        allRoleObjects = Resources.LoadAll<Role>("").ToList();
        CheckRoles();
    }

    private void CheckRoles()
    {
        qualifiedRoles = new List<Role>();

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
                qualifiedRoles.Add(currentRole);
            }
        }
    }
}
