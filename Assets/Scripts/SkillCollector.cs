using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nrjwolf.Tools.AttachAttributes;
using NaughtyAttributes;

[RequireComponent(typeof(Collider))]
public class SkillCollector : MonoBehaviour
{
    [Tooltip("Determines if this skill goes in the owned or unowned list")]
    [SerializeField] private bool goodCollector;

    //cached components
    [Header("Cached Components")]
    [FindObjectOfType] private SkillContainer skillContainer;

    private void Start()
    {
        if (skillContainer == null)
        {
            skillContainer = FindObjectOfType<SkillContainer>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "skill")
        {
            skillContainer.AssignSkill(goodCollector,
            other.GetComponent<SkillObject>().Skill);
        }
    }
}
