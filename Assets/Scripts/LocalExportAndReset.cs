using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#else
using System.IO;
#endif

public class LocalExportAndReset : MonoBehaviour
{

#if UNITY_WEBGL && !UNITY_EDITOR
    //sourced from https://pixeleuphoria.com/blog/index.php/2020/04/27/unity-webgl-download-content/
    [DllImport("__Internal")]
    public static extern void BrowserTextDownload(string filename, string textContent);
#endif


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.O))
                {
                    if (Input.GetKey(KeyCode.N))
                    {
                        ExportAndReset();
                    }
                }
            }
        }
    }

    void ExportAndReset()
    {
        //make sure we have save data to begin with
        if (PlayerPrefs.HasKey("SaveData"))
        {
            //gather up the data
            string saveData = PlayerPrefs.GetString("SaveData");

#if UNITY_WEBGL && !UNITY_EDITOR
            //download the data (this is calling into Plugins/JSDownload.jslib)
            //because this uses browser download functionality it doesn't over write previous downloaded data!
            BrowserTextDownload("ApplicantData.json", saveData);
            Debug.LogFormat("Wrote {0} to downloaded file and cleared local stored applicants", saveData);
#else

            //this is for non-web gl builds (unexpected but whatever)
            //create a folder in my documents if one doesn't exist
            string foldername = "\\GamesYall";
            DirectoryInfo info = Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + foldername);

            //create the filename with the current timestamp so it doesn't override previous saves
            string filename = string.Format("{0}\\ApplicantData{1}.json", foldername, System.DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));


            System.IO.File.WriteAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + filename, saveData);
            Debug.LogFormat("Wrote {0} to disk", saveData);
#endif
            //gets rid of the data - it doesn't need to be saved locally anymore
            PlayerPrefs.DeleteKey("SaveData");
            Debug.Log("Player Pref data reset.");
        }
    }
}

