using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class CSV_Writer : MonoBehaviour
{
    //Black Mug Values
    string M_filename = "";
    string tag1 = "mug1";
    private float MposX;
    private float MposY;
    private float MposZ;
    private float MrotX;
    private float MrotY;
    private float MrotZ;
    private bool header1;
    //Blue Mug Values
    string M2_filename = "";
    string tag2 = "mug2";
    private float M2posX;
    private float M2posY;
    private float M2posZ;
    private float M2rotX;
    private float M2rotY;
    private float M2rotZ;
    private bool header2;
    //Right Controller Values
    string C_filename = "";
    string tag3 = "handR";
    private float CposX;
    private float CposY;
    private float CposZ;
    private float CrotX;
    private float CrotY;
    private float CrotZ;
    private bool header3;

    // Start is called before the first frame update
    void Start()
    {
        M_filename = Application.dataPath + "/LoggedFiles/BlackMug_Logs.csv";
        header1 = false;
        M2_filename = Application.dataPath + "/LoggedFiles/BlueMug_Logs.csv";
        header2 = false;
        C_filename = Application.dataPath + "/LoggedFiles/RightController_Logs.csv";
        header3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        MposX = GameObject.FindGameObjectWithTag(tag1).transform.position.x;
        MposY = GameObject.FindGameObjectWithTag(tag1).transform.position.y;
        MposZ = GameObject.FindGameObjectWithTag(tag1).transform.position.z;
        MrotX = GameObject.FindGameObjectWithTag(tag1).transform.rotation.y;
        MrotY = GameObject.FindGameObjectWithTag(tag1).transform.rotation.y;
        MrotZ = GameObject.FindGameObjectWithTag(tag1).transform.rotation.z;

        M2posX = GameObject.FindGameObjectWithTag(tag2).transform.position.x;
        M2posY = GameObject.FindGameObjectWithTag(tag2).transform.position.y;
        M2posZ = GameObject.FindGameObjectWithTag(tag2).transform.position.z;
        M2rotX = GameObject.FindGameObjectWithTag(tag2).transform.rotation.y;
        M2rotY = GameObject.FindGameObjectWithTag(tag2).transform.rotation.y;
        M2rotZ = GameObject.FindGameObjectWithTag(tag2).transform.rotation.z;

        CposX = GameObject.FindGameObjectWithTag(tag3).transform.position.x;
        CposY = GameObject.FindGameObjectWithTag(tag3).transform.position.y;
        CposZ = GameObject.FindGameObjectWithTag(tag3).transform.position.z;
        CrotX = GameObject.FindGameObjectWithTag(tag3).transform.rotation.y;
        CrotY = GameObject.FindGameObjectWithTag(tag3).transform.rotation.y;
        CrotZ = GameObject.FindGameObjectWithTag(tag3).transform.rotation.z;

        WriteCSV();
    }

    public void WriteCSV()
    {
        TextWriter tw_M = new StreamWriter(M_filename, true);

        if (header1 == false)
        {
            tw_M.WriteLine("Object Name, Position x, Position y, Position z, Rotation x, Rotation y, Rotation z");

            tw_M.Close();

            header1 = true;
        }
        else
        {

            tw_M.WriteLine("Black Mug" + "," + MposX + "," + MposY + "," + MposZ + "," + MrotX + "," + MrotY + "," + MrotZ);

            tw_M.Close();
        }


        TextWriter tw_M2 = new StreamWriter(M2_filename, true);

        if (header2 == false)
        {
            tw_M2.WriteLine("Object Name, Position x, Position y, Position z, Rotation x, Rotation y, Rotation z");

            tw_M2.Close();

            header2 = true;
        }
        else
        {

            tw_M2.WriteLine("Blue Mug" + "," + MposX + "," + MposY + "," + MposZ + "," + MrotX + "," + MrotY + "," + MrotZ);

            tw_M2.Close();
        }


        TextWriter tw_C = new StreamWriter(C_filename, true);

        if (header3 == false)
        {
            tw_C.WriteLine("Object Name, Position x, Position y, Position z, Rotation x, Rotation y, Rotation z");

            tw_C.Close();

            header3 = true;
        }
        else
        {

            tw_C.WriteLine("Right Controller" + "," + MposX + "," + MposY + "," + MposZ + "," + MrotX + "," + MrotY + "," + MrotZ);

            tw_C.Close();
        }
    }
}
