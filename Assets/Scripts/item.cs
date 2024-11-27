using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class item : MonoBehaviour
{
    public int itemID;
    public string itemName;
    public TMP_Text itemNameText;
    public bool select;

    private void Start()
    {
        itemNameStart();
        itemNameText.text = itemName;
    }
    public void Selected()
    {
        var items = FindObjectsOfType<item>();
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<item>().select = false;
        }
        select = true;
        if(itemID == 5)
        {
            GameObject DIR = FindObjectOfType<DiagnosticInteractiveRay>().gameObject;
            DIR.GetComponent<DiagnosticInteractiveRay>()._Computer.GetComponent<ComputerSettings>()._CoolerP.SetActive(true);
        }
        else
        {
            GameObject DIR = FindObjectOfType<DiagnosticInteractiveRay>().gameObject;
            DIR.GetComponent<DiagnosticInteractiveRay>()._Computer.GetComponent<ComputerSettings>()._CoolerP.SetActive(false);
        }
        if(itemID == 2)
        {
            GameObject DIR = FindObjectOfType<DiagnosticInteractiveRay>().gameObject;
            DIR.GetComponent<DiagnosticInteractiveRay>()._Computer.GetComponent<ComputerSettings>()._CPUP.SetActive(true);
        }
        else
        {
            GameObject DIR = FindObjectOfType<DiagnosticInteractiveRay>().gameObject;
            DIR.GetComponent<DiagnosticInteractiveRay>()._Computer.GetComponent<ComputerSettings>()._CPUP.SetActive(false);
        }
    }
    private void itemNameStart()
    {
        switch (itemID)
        {
            case 1:
                itemName = "RAM";
                break;
            case 2:
                itemName = "CPU";
                break;
            case 3:
                itemName = "GPU";
                break;
            case 4:
                itemName = "PW";
                break;
            case 5:
                itemName = "CL";
                break;

                
        }
    }
}
