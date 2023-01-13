using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{
    [SerializeField] private TextAsset descriptionJSON;

    [SerializeField] private DescriptionFromJSONList descriptions;

    public DescriptionFromJSONList Descriptions
    {
        get => descriptions;
    }

    void Onvalidate()
    {
        descriptions = JsonUtility.FromJson<DescriptionFromJSONList>(descriptionJSON.ToString());
    }
}
