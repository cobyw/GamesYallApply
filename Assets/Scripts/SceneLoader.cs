using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private bool listenForReset = true;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        if (listenForReset)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.S))
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        if (Input.GetKey(KeyCode.F))
                        {
                            if (Input.GetKeyUp(KeyCode.L))
                            {
                                SceneManager.LoadScene("Intro");
                            }
                        }
                    }
                }
            }
        }
    }
}
