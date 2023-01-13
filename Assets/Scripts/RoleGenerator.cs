using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(RoleContainer))]
[RequireComponent(typeof(AnswerSaver))]
public class RoleGenerator : MonoBehaviour
{
    [SerializeField] private RoleContainer roleContrainer;
    [SerializeField] private RoleObject roleObjectPrefab;
    [SerializeField] private TextMeshPro textMeshPro;

    [SerializeField] private GameObject completeUIContainer;
    [SerializeField] private GameObject resetRequiredUIContainer;
    [SerializeField] private GameObject incompleteUIContainer;

    [SerializeField] private List<RoleObject> roleObjects;

    [SerializeField] private string initialString = "Add roles to the blue area and press \"Bank Selected\" to bank them for application!";
    [SerializeField] private string onlyVolunteerSkills = "Join in when you can as a volunteer to gain skills with us! After you've volunteered twice please consider applying again for a committee position!";
    [SerializeField] private string onlyVolunteerTime = "Join in when you can as a volunteer! If your schedule opens up in the future, please consider applying again for a committee position.";
    [SerializeField] private string conStringPrefix = "The roles you are applying for are: \n";
    [SerializeField] private string conString = "";

    [SerializeField] private Skill timeSkill;

    private int numberSelected = 0;
    private int numberBanked = 0;

    [SerializeField] private AnswerSaver answerSaver;


    private static RoleGenerator _instance;

    public static RoleGenerator Instance
    {
        get
        {
            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (roleContrainer == null)
        {
            roleContrainer = GetComponent<RoleContainer>();
        }

        numberSelected = 0;

        CheckForOnlyVolunteer();
        GenerateRoles();
        CheckIfAllBanked();
    }

    private void CheckForOnlyVolunteer()
    {
        //are they only qualified to volunteer?
        if (roleContrainer.QualifiedRoles.Count == 1)
        {
            //is it because they don't have time?
            if (!timeSkill.HasSkill)
            {
                textMeshPro.text = onlyVolunteerTime;
            }
            //or is it because they just need to gain skills?
            else
            {
                textMeshPro.text = onlyVolunteerSkills;
            }

        }
    }

    private void GenerateRoles()
    {
        roleObjects = new List<RoleObject>();

        foreach (Role role in roleContrainer.QualifiedRoles)
        {
            RoleObject currentObject = Instantiate(roleObjectPrefab, transform);
            currentObject.Role = role;
            roleObjects.Add(currentObject);
        }
    }

    public void ResetNotBanked()
    {
        foreach (RoleObject currentObject in roleObjects)
        {
            if (!currentObject.banked)
            {
                currentObject.ResetRole();
                currentObject.transform.position = roleObjectPrefab.transform.position;
                currentObject.gameObject.SetActive(true);
            }
        }
    }

    public void ResetAll()
    {
        foreach (RoleObject currentObject in roleObjects)
        {
            currentObject.ResetRole();
            currentObject.transform.position = roleObjectPrefab.transform.position;
            currentObject.gameObject.SetActive(true);

            conString = initialString;
            textMeshPro.text = conString;

        }

        numberBanked = 0;
        numberSelected = 0;
        CheckIfAllBanked();
    }

    public void BankSelected()
    {
        numberSelected = 0;
        numberBanked = 0;

        conString = conStringPrefix;

        foreach (RoleObject currentObject in roleObjects)
        {
            if (currentObject.selected)
            {
                numberSelected++;

                currentObject.banked = true;
                currentObject.gameObject.SetActive(false);

                conString += "\n" + currentObject.Role.NameOfRole;
            }

            if (currentObject.banked)
            {
                numberBanked++;
            }
        }

        if (numberSelected == 0)
        {
            conString = initialString;
        }

        textMeshPro.text = conString;

        CheckIfAllBanked();
    }

    public void BankDiscarded()
    {
        numberBanked = 0;

        foreach (RoleObject currentObject in roleObjects)
        {
            if (currentObject.discarded)
            {
                currentObject.banked = true;
                currentObject.gameObject.SetActive(false);
            }

            if (currentObject.banked)
            {
                numberBanked++;
            }
        }

        CheckIfAllBanked();
    }

    public void AutoBank(RoleObject roleObject)
    {
        roleObject.banked = true;
        roleObject.gameObject.SetActive(false);
        numberBanked++;

        if (roleObject.selected)
        {
            numberSelected++;

            //if this is our first one we need to initialize the constring
            if (numberSelected == 1)
            {
                conString = conStringPrefix;
            }

            //then we add the new role
            conString += "\n" + roleObject.Role.NameOfRole;
            textMeshPro.text = conString;
        }

            CheckIfAllBanked();
    }

    private void CheckIfAllBanked()
    {
        //looks to see if the number of roles we have banked is the same as the total number of roles
        bool allBanked = (numberBanked >= roleObjects.Count);

        bool roleSelected = (numberSelected > 0);

        //enables the complete container if all the roles are sorted and at least one is selected (includes the complete button)
        completeUIContainer.SetActive(allBanked && roleSelected);

        //enables the reset required container if all the roles are sorted but none are selected
        resetRequiredUIContainer.SetActive(allBanked && !roleSelected);

        //enables the incomplete container if some roles remain (includes the buttons to bank roles and reset the roles that aren't banked)
        incompleteUIContainer.SetActive(!allBanked);

        if (allBanked && roleSelected)
        {
            string tempString = string.Empty;
            foreach (RoleObject currentObject in roleObjects)
            {
                if (currentObject.selected)
                {
                    tempString += currentObject.Role.NameOfRole + ',';
                }
            }

            answerSaver.saveAnswer(tempString);
        }


        SliderBrain.Instance.UpdateSlider(numberBanked, roleObjects.Count);
    }
}
