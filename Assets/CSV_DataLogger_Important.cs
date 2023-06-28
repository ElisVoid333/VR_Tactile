using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

struct InteractionItem
{
    public GameObject name;
    public float posX;
    public float posY;
    public float posZ;
    public float rotX;
    public float rotY;
    public float rotZ;

    public float PUposX;
    public float PUposY;
    public float PUposZ;
    public float PUrotX;
    public float PUrotY;
    public float PUrotZ;

    public float DposX;
    public float DposY;
    public float DposZ;
    public float DrotX;
    public float DrotY;
    public float DrotZ;
}

public class CSV_DataLogger_Important : MonoBehaviour
{
    [SerializeField] private OVRInput.Handedness m_handedness = OVRInput.Handedness.RightHanded;

    public string filename = ""; //input field for filename
    string filePath;
    string IDfilename = "/LoggedFiles/ParticipantID.csv";
    string IDfilePath;
    public string mug; //input field for mug tag
    public Grabbable grabMug; //input field for mug
    public string RightHand; //input field for right hand/controller tag
    public string LeftHand; //input field for left hand/controller tag
    public int numTrials; //input field for the number of trials required
    public int numBlocks; //input field for the number of blocks required
    public bool WriteLogFiles;
    public bool WriteHeader;

    private Scene scene;
    private InteractionItem Mug;
    private InteractionItem HandControllerL;
    private InteractionItem HandControllerR;
    private GameObject target;

    private string text;
    private string order;
    private int grabs = 0;
    private int prevGrabs = 0;
    private System.DateTime PUtime;
    private System.DateTime Dtime;
    private bool PUtimeset;
    private bool Dtimeset;
    private bool grabbed;
    private bool mugVisible;
    private int blockCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        Mug.name = GameObject.FindGameObjectWithTag(mug); // Get Gameobjects using the inputted tags
        HandControllerL.name = GameObject.FindGameObjectWithTag(LeftHand);
        HandControllerR.name = GameObject.FindGameObjectWithTag(RightHand);

        scene = SceneManager.GetActiveScene();
        IDfilePath = Application.dataPath + IDfilename;
        text = File.ReadLines(IDfilePath).Skip(0).Take(1).First(); //Read the participant ID from the ParticipantID file
        order = File.ReadLines(IDfilePath).Skip(1).Take(1).First(); //Read the order from the ParticipantID file
        filePath = Application.dataPath + filename + "_" + text + ".csv"; //set the filepath to write to
        target = GameObject.FindGameObjectWithTag("target");

        grabbed = false;
        PUtimeset = false;
        Dtimeset = false;
        mugVisible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Mug.posX = Mug.name.transform.position.x; // Update mugs current positions
        Mug.posY = Mug.name.transform.position.y;
        Mug.posZ = Mug.name.transform.position.z;
        Mug.rotX = Mug.name.transform.rotation.x; // Update mugs current rotations
        Mug.rotY = Mug.name.transform.rotation.y;
        Mug.rotZ = Mug.name.transform.rotation.z;
        if (m_handedness == OVRInput.Handedness.RightHanded)
        {
            HandControllerR.posX = HandControllerR.name.transform.position.x;
            HandControllerR.posY = HandControllerR.name.transform.position.y;
            HandControllerR.posZ = HandControllerR.name.transform.position.z;
            HandControllerR.rotX = HandControllerR.name.transform.rotation.x;
            HandControllerR.rotY = HandControllerR.name.transform.rotation.y;
            HandControllerR.rotZ = HandControllerR.name.transform.rotation.z;
        }else if(m_handedness == OVRInput.Handedness.LeftHanded)
        {
            HandControllerL.posX = HandControllerL.name.transform.position.x;
            HandControllerL.posY = HandControllerL.name.transform.position.y;
            HandControllerL.posZ = HandControllerL.name.transform.position.z;
            HandControllerL.rotX = HandControllerL.name.transform.rotation.x;
            HandControllerL.rotY = HandControllerL.name.transform.rotation.y;
            HandControllerL.rotZ = HandControllerL.name.transform.rotation.z;
        }

        for (int i = 1; i <= numBlocks; i++)
        {
            if (grabs == (numTrials * i) + 1)
            {
                if (blockCount > numBlocks)
                {
                    blockCount = 0;
                    //Mug.name.SetActive(false); // Hide Mug once all blocks are completed
                    mugVisible = false;
                }
                else if (blockCount == i && grabs == (numTrials * numBlocks))
                {
                    blockCount = 0;
                    //Mug.name.SetActive(false); // Hide Mug once all blocks are completed
                    mugVisible = false;
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
                    blockCount = 0;
                    //Mug.name.SetActive(false); // Hide Mug once all blocks are completed
                    mugVisible = false;
                }
            }
        }

        grabs = grabMug.grabs;
        grabbed = grabMug.isGrabbed;
        if (grabs != prevGrabs)
        {
            if (grabbed && !PUtimeset) // if the mug is picked up and pickup time hasn't been set yet, set the pickup values and time
            {
                PUtime = System.DateTime.Now;

                Mug.PUposX = Mug.posX;
                Mug.PUposY = Mug.posY;
                Mug.PUposZ = Mug.posZ;
                Mug.PUrotX = Mug.rotX;
                Mug.PUrotY = Mug.rotY;
                Mug.PUrotZ = Mug.rotZ;

                if (m_handedness == OVRInput.Handedness.RightHanded)
                {
                    HandControllerR.PUposX = HandControllerR.posX;
                    HandControllerR.PUposY = HandControllerR.posY;
                    HandControllerR.PUposZ = HandControllerR.posZ;
                    HandControllerR.PUrotX = HandControllerR.rotX;
                    HandControllerR.PUrotY = HandControllerR.rotY;
                    HandControllerR.PUrotZ = HandControllerR.rotZ;
                }
                else if (m_handedness == OVRInput.Handedness.LeftHanded)
                {
                    HandControllerL.PUposX = HandControllerL.posX;
                    HandControllerL.PUposY = HandControllerL.posY;
                    HandControllerL.PUposZ = HandControllerL.posZ;
                    HandControllerL.PUrotX = HandControllerL.rotX;
                    HandControllerL.PUrotY = HandControllerL.rotY;
                    HandControllerL.PUrotZ = HandControllerL.rotZ;
                }

                PUtimeset = true;
            }
            else if (!grabbed && !Dtimeset) // if the mug has been dropped and the drop time hasn't been set yet, set the drop values and time
            {
                Dtime = System.DateTime.Now;

                Mug.DposX = Mug.posX;
                Mug.DposY = Mug.posY;
                Mug.DposZ = Mug.posZ;
                Mug.DrotX = Mug.rotX;
                Mug.DrotY = Mug.rotY;
                Mug.DrotZ = Mug.rotZ;

                if (m_handedness == OVRInput.Handedness.RightHanded)
                {
                    HandControllerR.DposX = HandControllerR.posX;
                    HandControllerR.DposY = HandControllerR.posY;
                    HandControllerR.DposZ = HandControllerR.posZ;
                    HandControllerR.DrotX = HandControllerR.rotX;
                    HandControllerR.DrotY = HandControllerR.rotY;
                    HandControllerR.DrotZ = HandControllerR.rotZ;
                }
                else if (m_handedness == OVRInput.Handedness.LeftHanded)
                {
                    HandControllerL.DposX = HandControllerL.posX;
                    HandControllerL.DposY = HandControllerL.posY;
                    HandControllerL.DposZ = HandControllerL.posZ;
                    HandControllerL.DrotX = HandControllerL.rotX;
                    HandControllerL.DrotY = HandControllerL.rotY;
                    HandControllerL.DrotZ = HandControllerL.rotZ;
                }
                
                Dtimeset = true;

                if (!mugVisible)
                {
                    Mug.name.SetActive(mugVisible); // Hide Mug once all blocks are completed
                }else if (WriteLogFiles)
                {
                    WriteCSV(); // Write the values 
                }

                prevGrabs = grabs;
            }
        }
        else
        {
            PUtimeset = false;
            Dtimeset = false;
        }
    }

    public void WriteCSV()
    {
        TextWriter tw = new StreamWriter(filePath, true);

        if (WriteHeader == true)
        {
            tw.WriteLine("Participant ID, Condition, Ordering, Block Number, Trial Number, Trial Start Time, " +
                        "Start Mug Positon, , , " +
                        "Pickup Hand Position, , , " +
                        "Pickup Hand Rotation, , , Pickup Time,  " +
                        "Drop Mug Positon, , , " +
                        "Drop Hand Position, , , " +
                        "Drop Hand Rotation, , , Drop Time, " +
                        "Target Position");

            tw.Close();

            WriteHeader = false;
        }
        else if (m_handedness == OVRInput.Handedness.RightHanded) // Right hand values
        {
            tw.WriteLine(text + "," + scene.name + "," + order + "," + blockCount + "," + grabs + "," + PUtime + "," 
                        + Mug.PUposX + "," + Mug.PUposY + "," + Mug.PUposZ + "," 
                        + HandControllerR.PUposX + "," + HandControllerR.PUposY + "," + HandControllerR.PUposZ + "," 
                        + HandControllerR.PUrotX + "," + HandControllerR.PUrotY + "," + HandControllerR.PUrotZ + "," + PUtime + "," 
                        + Mug.DposX + "," + Mug.DposY + "," + Mug.DposZ + "," 
                        + HandControllerR.DposX + "," + HandControllerR.DposY + "," + HandControllerR.DposZ + "," 
                        + HandControllerR.DrotX + "," + HandControllerR.DrotY + "," + HandControllerR.DrotZ + "," + Dtime + "," 
                        + target.transform.position.x + "," + target.transform.position.y + "," + target.transform.position.z);

            tw.Close();
        }
        else if (m_handedness == OVRInput.Handedness.LeftHanded) // Left hand values
        {
            tw.WriteLine(text + "," + scene.name + "," + order + "," + blockCount + "," + grabs + "," + PUtime + ","
                        + Mug.PUposX + "," + Mug.PUposY + "," + Mug.PUposZ + ","
                        + HandControllerL.PUposX + "," + HandControllerL.PUposY + "," + HandControllerL.PUposZ + ","
                        + HandControllerL.PUrotX + "," + HandControllerL.PUrotY + "," + HandControllerL.PUrotZ + "," + PUtime + ","
                        + Mug.DposX + "," + Mug.DposY + "," + Mug.DposZ + ","
                        + HandControllerL.DposX + "," + HandControllerL.DposY + "," + HandControllerL.DposZ + ","
                        + HandControllerL.DrotX + "," + HandControllerL.DrotY + "," + HandControllerL.DrotZ + "," + Dtime + ","
                        + target.transform.position.x + "," + target.transform.position.y + "," + target.transform.position.z);

            tw.Close();
        }

    }

}