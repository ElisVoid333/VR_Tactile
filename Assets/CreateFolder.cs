using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class CreateFolder : MonoBehaviour
{
    public TMP_InputField targetText;
    string IDfilename = "/LoggedFiles/ParticipantID.csv";
    string IDfilePath;

    // Start is called before the first frame update
    void Start()
    {
        IDfilePath = Application.dataPath + IDfilename;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteIDcsv()
    {
        File.WriteAllText(IDfilePath, targetText.text);
    }
    
}
