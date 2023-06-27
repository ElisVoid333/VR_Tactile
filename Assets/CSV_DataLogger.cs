using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public int numTrials;
    public int numBlocks;
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
    private string order;
    private GameObject item;
    private int grabs = 0;
    private bool grabbed;
    private int blockCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        IDfilePath = Application.dataPath + IDfilename;
        text = File.ReadLines(IDfilePath).Skip(0).Take(1).First();
        order = File.ReadLines(IDfilePath).Skip(1).Take(1).First();
        //text = File.ReadAllText(IDfilePath);
        filePath = Application.dataPath + filename + "_" + text + ".csv";
        item = GameObject.FindGameObjectWithTag(tag1);

        grabbed = false;
        button.SetActive(false);
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

        grabs = isGrabbed.grabs;
        grabbed = isGrabbed.isGrabbed;

        for (int i = 1; i <= numBlocks; i++)
        {
            if (grabs == (numTrials * i) + 1)
            {
                if (blockCount > numBlocks)
                {
                    button.SetActive(true);
                    blockCount = 0;
                    break;
                }
                else if (blockCount == i)
                {
                    blockCount++;
                }
            }
            else
            {
                if (blockCount > numBlocks)
                {
                    button.SetActive(true);
                    blockCount = 0;
                    break;
                }
            }
        }

        if (WriteLogFiles)
        {
            WriteCSV();
        }
    }

    public void WriteCSV()
    {
        TextWriter tw = new StreamWriter(filePath, true);

        if (WriteHeader == true)
        {
            tw.WriteLine("Participant ID, Object Name, Position x, Position y, Position z, Rotation x, Rotation y, Rotation z, TimeStamp, Currently Being Held, Block Number, Trial Number, Condition, Ordering");

            tw.Close();

            WriteHeader = false;
        }
        else
        {

            tw.WriteLine(text + "," + tag1 + "," + posX + "," + posY + "," + posZ + "," + rotX + "," + rotY + "," + rotZ + "," + System.DateTime.Now + "," + grabbed + "," + blockCount + "," + grabs + "," + scene.name + "," + order);

            tw.Close();
        }

    }

}