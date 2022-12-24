using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider))]
public class RoleObject : MonoBehaviour
{
    [SerializeField] private Role role;
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private Vector3 finalScale = new Vector3(3, 1, 2);
    [SerializeField] private string GoodCubeName = "GoodCube";
    [SerializeField] private string BadCubeName = "BadCube";
    [SerializeField] private float timeToVanish = 5;

    public bool discarded = false;
    public bool selected = false;
    public bool banked = false;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public Role Role
    {
        get => role;
        set
                {
            role = value;
            SetName();
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        SetName();
    }
#endif

    public void SetName()
    {
        textMeshPro.text = role.NameOfRole;
        gameObject.name = "Role - " + role.NameOfRole;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collector")
        {
            StartCoroutine(ReduceOverTime());
            if (other.name == GoodCubeName && !discarded)
            {
                selected = true;
            }
            else if (other.name == BadCubeName && !selected)
            {
                discarded = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "collector")
        {
            ResetRole();
        }
    }

    public void ResetRole()
    {
        StopAllCoroutines();
        transform.localScale = originalScale;
        selected = false;
        discarded = false;
        banked = false;
    }

    private IEnumerator ReduceOverTime()
    {
        float timePassed = 0;
        while (timePassed < timeToVanish)
        {
            Vector3 newScale = new Vector3 (Mathf.Lerp(originalScale.x, finalScale.x, timePassed), Mathf.Lerp(originalScale.y, finalScale.y, timePassed/timeToVanish), originalScale.z);
            transform.localScale = newScale;
            timePassed += Time.deltaTime;
            yield return null;
        }

        RoleGenerator.Instance.AutoBank(this);
    }
}
