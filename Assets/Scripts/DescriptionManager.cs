using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

static class DescriptionManager
{

    [MenuItem("Edit/Update Descriptions")]
    static void UpdateDescriptions()
    {
        TextAsset descriptionJSON;

        DescriptionFromJSONList descriptions;
        List<Skill> skillObjectList;
        List<Role> allRoleObjects;

        //this is a nasty hack but whatever
        //this is loading all text assets and then arbitrarily using the first one loaded
        //this works for this project because we only have one json
        descriptionJSON = Resources.LoadAll<TextAsset>("").ToList()[0];

        descriptions = JsonUtility.FromJson<DescriptionFromJSONList>(descriptionJSON.ToString());
        skillObjectList = Resources.LoadAll<Skill>("").ToList();
        allRoleObjects = Resources.LoadAll<Role>("").ToList();

        bool descriptionUsed = false;
        int descriptionsUpdated = 0;

        foreach (DescriptionFromJSON description in descriptions.descriptionFromJSONList)
        {
            descriptionUsed = false;

            foreach (Skill skill in skillObjectList)
            {
                if (skill.NameOfSkill == description.nameOfRoleOrSkill)
                {
                    if (skill.DescriptionOfSkill != description.descriptionOfRoleOrSkill)
                    {
                        Debug.LogFormat("Updated skill {0}", description.nameOfRoleOrSkill);
                        skill.DescriptionOfSkill = description.descriptionOfRoleOrSkill;
                        EditorUtility.SetDirty(skill);
                        descriptionsUpdated++;
                    }
                    descriptionUsed = true;
                    break;
                }
            }

            if (!descriptionUsed)
            {
                foreach (Role role in allRoleObjects)
                {
                    if (role.NameOfRole == description.nameOfRoleOrSkill)
                    {
                        if (role.DescriptionOfRole != description.descriptionOfRoleOrSkill)
                        {
                            Debug.LogFormat("Updated role {0}", description.nameOfRoleOrSkill);
                            role.DescriptionOfRole = description.descriptionOfRoleOrSkill;
                            EditorUtility.SetDirty(role);
                            descriptionsUpdated++;
                        }
                        descriptionUsed = true;
                        break;
                    }
                }

            }

            if (!descriptionUsed)
            {
                Debug.LogErrorFormat("Unable to locate Role or Skill with name {0)}", description.nameOfRoleOrSkill);
            }
        }

        if (descriptionsUpdated == 0)
        {
            Debug.Log("Attempted to update descriptions but no descriptions to update!");
        }
        else
        {
            Debug.LogFormat("Updated {0} Descriptions. Saved changes.", descriptionsUpdated);
            EditorApplication.ExecuteMenuItem("File/Save Project");
        }
    }

}