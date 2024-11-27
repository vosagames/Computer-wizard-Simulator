using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableControl : MonoBehaviour
{
    [SerializeField] private Transform pcPosition1;
    [SerializeField] private Transform pcPosition2;
    [SerializeField] private Transform pcPosition3;

    [SerializeField] private bool freePlace1 = true;
    [SerializeField] private bool freePlace2 = true;
    [SerializeField] private bool freePlace3 = true;

    private void Start()
    {
        var computers = Object.FindObjectsOfType<ComputerSettings>();
        for(int i = 0;  i < computers.Length; i++)
        {
            computers[i].GetComponent<ComputerSettings>().placeNumber = i;
            Take(computers[i].gameObject);
        }
    }
    public void Take(GameObject computer)
    {
        if (freePlace1 == true && computer.GetComponent<ComputerSettings>().placeNumber == 0)
        {
            computer.transform.position = pcPosition1.position;
            computer.transform.rotation = pcPosition1.rotation;
            computer.transform.SetParent(pcPosition1);
            //computer.GetComponent<ComputerSettings>().placeNumber = 0;
            freePlace1 = false;
        }
        else if(freePlace2 == true && computer.GetComponent<ComputerSettings>().placeNumber == 1)
        {
            computer.transform.position = pcPosition2.position;
            computer.transform.rotation = pcPosition2.rotation;
            computer.transform.SetParent(pcPosition2);
           //computer.GetComponent<ComputerSettings>().placeNumber = 1;
            freePlace2 = false;
        }
        else if(freePlace3 == true && computer.GetComponent<ComputerSettings>().placeNumber == 2)
        {
            computer.transform.position = pcPosition3.position;
            computer.transform.rotation = pcPosition3.rotation;
            computer.transform.SetParent(pcPosition3);
           //computer.GetComponent<ComputerSettings>().placeNumber = 2;
            freePlace3 = false;
        }
    }
    public void Put(int number)
    {
        switch (number)
        {
            case 0:
                freePlace1 = true;
                break;
            case 1:
                freePlace2 = true;
                break;
            case 2:
                freePlace3 = true;
                break;
        }
    }
}
