using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider))]
public class SkillObject : MonoBehaviour
{
    [SerializeField] private Skills skill;
    [SerializeField] private TextMeshPro textMeshPro;

    public Skills Skill
    {
        get
        {
            return skill;
        }
    }

    private void OnValidate()
    {
        textMeshPro.text = skill.NameOfSkill;
        gameObject.name = "Skill - " + skill.NameOfSkill;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collector")
        {
            StartCoroutine(DestroyOvertime());
        }
    }

    private IEnumerator DestroyOvertime()
    {
        float timeToVanish = 1;
        float timePassed = 0;
        float timeRemaining = 1;
        Vector3 originalScale = transform.localScale;
        while (timePassed < timeToVanish)
        {
            transform.localScale = originalScale *= timeRemaining;
            timePassed += Time.deltaTime;
            timeRemaining = timeToVanish - timePassed;
            yield return null;
        }
        Destroy(gameObject);
    }
}
