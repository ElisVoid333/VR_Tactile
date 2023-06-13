using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CSV_DataLogger : MonoBehaviour
{
    //Black Mug Values
    public string filename = "";
    string filePath;
    public string tag1 = "";
    public bool WriteLogFiles;
    private float posX;
    private float posY;
    private float posZ;
    private float rotX;
    private float rotY;
    private float rotZ;
    private bool header;


    // Start is called before the first frame update
    void Start()
    {
        header = false;
        filePath = Application.dataPath + filename;
    }

    // Update is called once per frame
    void Update()
    {
        posX = GameObject.FindGameObjectWithTag(tag1).transform.position.x;
        posY = GameObject.FindGameObjectWithTag(tag1).transform.position.y;
        posZ = GameObject.FindGameObjectWithTag(tag1).transform.position.z;
        rotX = GameObject.FindGameObjectWithTag(tag1).transform.rotation.y;
        rotY = GameObject.FindGameObjectWithTag(tag1).transform.rotation.y;
        rotZ = GameObject.FindGameObjectWithTag(tag1).transform.rotation.z;

        if (WriteLogFiles)
        {
            WriteCSV();
        }
        //WriteCSV();
    }

    public void WriteCSV()
    {
        TextWriter tw = new StreamWriter(filePath, true);

        if (header == false)
        {
            tw.WriteLine("Object Name, Position x, Position y, Position z, Rotation x, Rotation y, Rotation z");

            tw.Close();

            header = true;
        }
        else
        {

            tw.WriteLine(tag1 + "," + posX + "," + posY + "," + posZ + "," + rotX + "," + rotY + "," + rotZ);

            tw.Close();
        }
    }
}