using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonVisible : MonoBehaviour
{
    public GameObject RedButton;

    // Start is called before the first frame update
    void Start()
    {
        RedButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowButton()
    {
        RedButton.SetActive(true);
    }

    public void HideButton()
    {
        RedButton.SetActive(false);
    }
}
