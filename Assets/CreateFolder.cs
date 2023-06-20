using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class CreateFolder : MonoBehaviour
{
    public TMP_InputField targetText;
    public int order;
    string IDfilename = "/LoggedFiles/ParticipantID.csv";
    string IDfilePath;
    string orderStr = "";
    private System.Random rnd = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        IDfilePath = Application.dataPath + IDfilename;
        //order = rnd.Next(1,4);
        if (order == 1)
        {
            orderStr = "ABDC";
        }else if (order == 2)
        {
            orderStr = "BCAD";
        }
        else if (order == 3)
        {
            orderStr = "CDBA";
        }
        else if (order == 4)
        {
            orderStr = "DACB";
        }
        else
        {
            orderStr = "No Order";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteIDcsv()
    {
        File.WriteAllText(IDfilePath, targetText.text + "\n" + orderStr);
    }
}
