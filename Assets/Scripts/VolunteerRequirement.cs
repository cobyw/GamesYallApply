using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolunteerRequirement : MonoBehaviour
{
    //This script does not work and I do not know why.
    //I adjusted the text to be less specific in retaliation.
    [SerializeField] private Skill haveVolunteeredTwice;

    void Awake()
    {
        gameObject.SetActive(!haveVolunteeredTwice.HasSkill);
    }
}
