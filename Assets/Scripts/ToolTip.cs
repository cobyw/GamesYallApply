using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolTip : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private TextMeshProUGUI tmpro;
    [SerializeField] private Vector3 offset;

    public void OpenToolTip(string text)
    {
        tmpro.text = text;
        rectTransform.gameObject.SetActive(true);
    }

    public void CloseToolTip()
    {
        rectTransform.gameObject.SetActive(false);
    }

    private void Start()
    {
        if (rectTransform == null)
        {
            GetComponentInChildren<RectTransform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        rectTransform.anchoredPosition = Input.mousePosition + offset;
    }
}
