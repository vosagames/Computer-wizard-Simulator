using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadyPC : MonoBehaviour
{
    [SerializeField] private TMP_Text readyPCcount;
    [SerializeField] GameObject ErrorMesseage, ReadyMesseage;

    private int Counter;

    public void CheckPC(GameObject Computer)
    {
        if (Computer.GetComponent<ComputerSettings>().RAM1 == true && Computer.GetComponent<ComputerSettings>().RAM2 == true && Computer.GetComponent<ComputerSettings>().Cooler == true && Computer.GetComponent<ComputerSettings>().CPU == true && Computer.GetComponent<ComputerSettings>().GPU == true && Computer.GetComponent<ComputerSettings>().Power == true)
        {
            UpdateCountPC();
            Destroy(Computer);
            ReadyMesseage.SetActive(true);
            Invoke("ReadyHide", 2f);
        }
        else
        {
            ErrorMesseage.SetActive(true);
            Invoke("ErrorHide", 2f);
        }
    }
    private void ErrorHide() => ErrorMesseage.SetActive(false);
    private void ReadyHide() => ReadyMesseage.SetActive(false);
         



    private void UpdateCountPC()
    {
        Counter++;
        readyPCcount.text = $"Собрано компьютеров: {Counter}/3";
        if(Counter == 3)
        {
            Finish();
        }
    }
    private void Finish()
    {

    }
}
