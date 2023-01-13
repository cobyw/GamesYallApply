using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerLength = 300;
    [SerializeField] private TextMeshProUGUI tmpro;
    [SerializeField] private string timerResetSceneName = "BoringForm";
    [SerializeField] private string[] timerStopScenes;


    private bool timerRunning;
    private float currentSeconds;
    private float timeRemaining;

    private static Timer _instance;

    public static Timer Instance
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
            DontDestroyOnLoad(this);
            _instance = this;

        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //resets the timer when loading into the reset scene
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == timerResetSceneName)
        {
            timerRunning = true;
            currentSeconds = 0;
            timeRemaining = timerLength;
            tmpro.text = FormatTime(timeRemaining);
        }

        foreach (string stopSceneName in timerStopScenes)
        {
            if (scene.name == stopSceneName)
            {
                timerRunning = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSeconds = 0;
        timeRemaining = timerLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            currentSeconds += Time.deltaTime;
            timeRemaining = timerLength - currentSeconds;
            tmpro.text = FormatTime(timeRemaining);
        }
        else
        {
            tmpro.text = string.Empty;
        }
    }

    private static string FormatTime(float totalTimeSec)
    {
        string retval = string.Empty;

        if (totalTimeSec > 60)
        {
            retval = (Mathf.Floor(totalTimeSec / 60).ToString("0") + ":" + Mathf.FloorToInt(totalTimeSec % 60).ToString("00"));
        }
        else if (totalTimeSec > 0)
        {
            retval = (Mathf.FloorToInt(totalTimeSec % 60).ToString("00") + " s");
        }

        return retval;
    }
}
