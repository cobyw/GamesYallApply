using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{
    [SerializeField] private TextAsset descriptionJSON;

    [SerializeField] private DescriptionFromJSONList descriptions;

    public DescriptionFromJSONList Descriptions
    {
        get => descriptions;
    }

    [Button]
    void GetDescriptions()
    {
        descriptions = JsonUtility.FromJson<DescriptionFromJSONList>(descriptionJSON.ToString());
    }
}
