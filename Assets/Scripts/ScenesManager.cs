using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    private int order;
    readonly string scene1 = "VRTactile_Condition1";
    readonly string scene2 = "VRTactile_Condition2";
    readonly string scene3 = "VRTactile_Condition3";
    readonly string scene4 = "VRTactile_Condition4";
    readonly string sceneIn = "VRTactile_IDnumber_input";
    readonly string sceneEnd = "VRTactile_EndScene";

    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene()
    {
        order = PlayerPrefs.GetInt("conditionOrder");

        switch (order)
        {
            case (0):
                LoadNextScene(1);

                break;

            case (1):
                LoadNextScene(2);

                break;

            case (2):
                LoadNextScene(3);

                break;

            case (3):
                LoadNextScene(4);

                break;
            default:
                SceneManager.LoadScene(sceneEnd);

                break;
        }
    }

    public void LoadNextScene(int order) //This cycles the conditions in a latin square sequence determined by the order assigned
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
            if (order == 3) { SceneManager.LoadScene(sceneEnd); }
            if (order == 4) { SceneManager.LoadScene(scene3); }
        }else if(currentScene == scene2)
        {
            if (order == 1) { SceneManager.LoadScene(scene4); }
            if (order == 2) { SceneManager.LoadScene(scene3); } 
            if (order == 3) { SceneManager.LoadScene(scene1); }
            if (order == 4) { SceneManager.LoadScene(sceneEnd); }
        }else if(currentScene == scene3)
        {
            if (order == 1) { SceneManager.LoadScene(sceneEnd); }
            if (order == 2) { SceneManager.LoadScene(scene1); } 
            if (order == 3) { SceneManager.LoadScene(scene4); }
            if (order == 4) { SceneManager.LoadScene(scene2); }
        }else if(currentScene == scene4)
        {
            if (order == 1) { SceneManager.LoadScene(scene3); }
            if (order == 2) { SceneManager.LoadScene(sceneEnd); } 
            if (order == 3) { SceneManager.LoadScene(scene2); }
            if (order == 4) { SceneManager.LoadScene(scene1); }
        }else
        {
            SceneManager.LoadScene(sceneEnd);
        }
    }
}
