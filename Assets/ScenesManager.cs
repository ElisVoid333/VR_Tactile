using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    string IDfilename = "/LoggedFiles/ParticipantID.csv";
    string IDfilePath;
    private string order;
    string scene1 = "VRTactile_Condition1";
    string scene2 = "VRTactile_Condition2";
    string scene3 = "VRTactile_Condition3";
    string scene4 = "VRTactile_Condition4";
    string sceneIn = "VRTactile_IDnumber_input";
    string sceneEnd = "VRTactile_EndScene";

    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene()
    {
        IDfilePath = Application.dataPath + IDfilename;
        order = File.ReadLines(IDfilePath).Skip(1).Take(1).First();
        if (order == "ABDC")
        {
            LoadNextScene(1);
        }else if (order == "BCAD")
        {
            LoadNextScene(2);
        }
        else if (order == "CDBA")
        {
            LoadNextScene(3);
        }
        else if (order == "DACB")
        {
            LoadNextScene(4);
        }
        else
        {
            SceneManager.LoadScene(sceneEnd);
        }
    }

    public void LoadNextScene(int order)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        //Debug.Log("Current Scene = " + currentScene);
        if (currentScene == sceneIn)
        {
            if(order == 1) { SceneManager.LoadScene(scene1); }
            if(order == 2) { SceneManager.LoadScene(scene2); }
            if(order == 3) { SceneManager.LoadScene(scene3); }
            if(order == 4) { SceneManager.LoadScene(scene4); }
        }else if(currentScene == scene1)
        {
            if (order == 1) { SceneManager.LoadScene(scene2); }
            if (order == 2) { SceneManager.LoadScene(scene4); } 
            if (order == 3) { SceneManager.LoadScene(scene2); }
            if (order == 4) { SceneManager.LoadScene(sceneEnd); }
        }else if(currentScene == scene2)
        {
            if (order == 1) { SceneManager.LoadScene(scene3); }
            if (order == 2) { SceneManager.LoadScene(scene1); } 
            if (order == 3) { SceneManager.LoadScene(sceneEnd); }
            if (order == 4) { SceneManager.LoadScene(scene1); }
        }else if(currentScene == scene3)
        {
            if (order == 1) { SceneManager.LoadScene(scene4); }
            if (order == 2) { SceneManager.LoadScene(sceneEnd); } 
            if (order == 3) { SceneManager.LoadScene(scene4); }
            if (order == 4) { SceneManager.LoadScene(scene2); }
        }else if(currentScene == scene4)
        {
            if (order == 1) { SceneManager.LoadScene(sceneEnd); }
            if (order == 2) { SceneManager.LoadScene(scene3); } 
            if (order == 3) { SceneManager.LoadScene(scene1); }
            if (order == 4) { SceneManager.LoadScene(scene3); }
        }else
        {
            SceneManager.LoadScene(sceneEnd);
        }
    }
}
