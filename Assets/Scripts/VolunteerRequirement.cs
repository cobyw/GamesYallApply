using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolunteerRequirement : MonoBehaviour
{
    [SerializeField] private Skill haveVolunteeredTwice;

    // Start is called before the first frame update
    void Start()
    {
        if (haveVolunteeredTwice.HasSkill)
        {
            gameObject.SetActive(false);
        }
    }
}
