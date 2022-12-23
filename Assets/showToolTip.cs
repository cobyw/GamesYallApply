using UnityEngine;
using System.Collections;
using TMPro;

[RequireComponent(typeof(SkillObject))]
public class showToolTip : MonoBehaviour
{
    private ToolTip toolTip;
    private SkillObject skillObject;
    private bool hovered = false;
    private bool mouseDown = false;
    public bool initialized = false;

    private void Start()
    {
        Init();

        UpdateTooltip();
    }

    private void Init()
    {
        if (!initialized)
        {
            if (skillObject == null)
            {
                skillObject = FindObjectOfType<SkillObject>();
            }

            if (toolTip == null)
            {
                toolTip = FindObjectOfType<ToolTip>();
            }
        }
    }

    private void OnMouseEnter()
    {
        hovered = true;
        UpdateTooltip();
    }

    private void OnMouseExit()
    {
        hovered = false;
        UpdateTooltip();
    }

    private void OnMouseDown()
    {
        mouseDown = true;
        UpdateTooltip();
    }

    private void OnMouseUp()
    {
        mouseDown = false;
        UpdateTooltip();
    }


    private void UpdateTooltip()
    {
        Init();

        if (hovered && !mouseDown)
        {
            toolTip.OpenToolTip(skillObject.Skill.DescriptionOfSkill);
        }
        else
        {
            toolTip.CloseToolTip();
        }
    }
}