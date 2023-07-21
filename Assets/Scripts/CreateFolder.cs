using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

/*
 * This is the class that creates the csv data logging files and writes the headers. These files later get the data written into them
 * in CSV_DataLogger and CSV_DataLogger_Important.
 */

public class CreateFolder : MonoBehaviour
{
    public TMP_InputField targetText;
    public string mainfilename = "";
    public string filename = "";
    string mainfilePath;
    string filePath;
    public bool WriteMainHeader;
    public bool WriteHeader;


    // Start is called before the first frame update
    public void StartTask()
    {
        int id = int.Parse(targetText.text);
        PlayerPrefs.SetInt("pid", id);

        int conditionOrder = GetConditionOrdering(id);
        PlayerPrefs.SetInt("conditionOrder", conditionOrder);
        WriteMainCSV();
        WriteCSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int GetConditionOrdering(int pid)
    {

        int order = pid % 4;

        return order;
    }

    public void WriteMainCSV()
    {
        mainfilePath = Application.dataPath + mainfilename + "_" + targetText.text + ".csv";

        TextWriter tw = new StreamWriter(mainfilePath, true);

        if (WriteMainHeader == true)
        {
            tw.WriteLine("Participant ID, Object Name, " +
                        "Position x, Position y, Position z, " +
                        "Rotation x, Rotation y, Rotation z, " +
                        "TimeStamp, Currently Being Held, Block Number, Trial Number, Condition, Ordering");

            tw.Close();

            WriteMainHeader = false;
        }

    }

    public void WriteCSV()
    {
        filePath = Application.dataPath + filename + "_" + targetText.text + ".csv";

        TextWriter sw = new StreamWriter(filePath, true);

        if (WriteHeader == true)
        {
            sw.WriteLine("Participant ID, Condition, Ordering, Block Number, Trial Number, Trial Start Time, " +
                        "Start Mug Positon X, Start Mug Positon Y, Start Mug Positon Z, " +
                        "Pickup Hand Position X, Pickup Hand Position Y, Pickup Hand Position Z, " +
                        "Pickup Hand Rotation X, Pickup Hand Rotation Y, Pickup Hand Rotation Z, Pickup Time,  " +
                        "Drop Mug Positon X, Drop Mug Positon Y, Drop Mug Positon Z, " +
                        "Drop Hand Position X, Drop Hand Position Y, Drop Hand Position Z, " +
                        "Drop Hand Rotation X, Drop Hand Rotation Y, Drop Hand Rotation Z, Drop Time, " +
                        "Target Position X, Target Position Y, Target Position Z");

            sw.Close();

            WriteHeader = false;
        }

    }
}
