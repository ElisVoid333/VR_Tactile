using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSV_DataLogger : MonoBehaviour
{
    //Black Mug Values
    public string filename = "";
    string filePath;
    string IDfilename = "/LoggedFiles/ParticipantID.csv";
    string IDfilePath;
    public string tag1 = "";
    public bool WriteLogFiles;
    public Grabbable isGrabbed;
    public bool WriteHeader;
    public GameObject button;

    private Scene scene;
    private float posX;
    private float posY;
    private float posZ;
    private float rotX;
    private float rotY;
    private float rotZ;
    private string text;
    private GameObject item;
    private int grabs = 0;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        IDfilePath = Application.dataPath + IDfilename;
        text = File.ReadAllText(IDfilePath);
        filePath = Application.dataPath + filename + "_" + text + ".csv";
        item = GameObject.FindGameObjectWithTag(tag1);
        if (tag1 == "mug1")
        {
            button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        posX = item.transform.position.x;
        posY = item.transform.position.y;
        posZ = item.transform.position.z;
        rotX = item.transform.rotation.y;
        rotY = item.transform.rotation.y;
        rotZ = item.transform.rotation.z;
        if (tag1 == "mug1")
        {
            grabs = isGrabbed.grabs;
            if(grabs > 5)
            {
                button.SetActive(true);
            }
        }

        if (WriteLogFiles)
        {
            WriteCSV();
        }
        //WriteCSV();
    }

    public void WriteCSV()
    {
        TextWriter tw = new StreamWriter(filePath, true);

        if (tag1 == "mug1")
        {
            if (WriteHeader == true)
            {
                tw.WriteLine("Object Name, Position x, Position y, Position z, Rotation x, Rotation y, Rotation z, TimeStamp, Times Picked Up, " + scene.name);

                tw.Close();

                WriteHeader = false;
            }
            else
            {

                tw.WriteLine(tag1 + "," + posX + "," + posY + "," + posZ + "," + rotX + "," + rotY + "," + rotZ + "," + grabs + "," + System.DateTime.Now);

                tw.Close();
            }
        }else
        {
            if (WriteHeader == true)
            {
                tw.WriteLine("Object Name, Position x, Position y, Position z, Rotation x, Rotation y, Rotation z, TimeStamp, " + scene.name);

                tw.Close();

                WriteHeader = false;
            }
            else
            {

                tw.WriteLine(tag1 + "," + posX + "," + posY + "," + posZ + "," + rotX + "," + rotY + "," + rotZ + "," + System.DateTime.Now);

                tw.Close();
            }
        }

    }

}