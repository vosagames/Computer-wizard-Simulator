using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSettings : MonoBehaviour
{
    public bool isRepairTable = false;
    public int placeNumber;

    public GameObject _RAM1, _RAM2, _Cooler, _CPU, _GPU, _Power;
    public GameObject _RAM1P, _RAM2P, _CoolerP, _CPUP, _GPUP, _PowerP;  
    
    public bool RAM1, RAM2;
    public bool Cooler;
    public bool CPU;
    public bool GPU;
    public bool Power;

    private void Start()
    {
        PCstat();
    }

    public void PCstat()
    {
        if(RAM1 == true) 
        {
            _RAM1.SetActive(true);
            _RAM1P.SetActive(false);
        }
        else
        {
            _RAM1.SetActive(false);
            _RAM1P.SetActive(true);
        }
        if(RAM2 == true)
        {
            _RAM2.SetActive(true);
            _RAM2P.SetActive(false);
        }
        else
        {
            _RAM2.SetActive(false);
            _RAM2P.SetActive(true);
        }
        if(CPU == true)
        {
            _CPU.SetActive(true);
            _CPUP.SetActive(false);
        }
        else
        {
            _CPU.SetActive(false);
        }
        if(Cooler == true) 
        {
            _Cooler.SetActive(true);
            _CoolerP.SetActive(false);
        }
        else
        {
            _Cooler.SetActive(false);
        }
        if(GPU == true)
        {
            _GPU.SetActive(true);
            _GPUP.SetActive(false);
        }
        else
        {
            _GPU.SetActive(false);
            _GPUP.SetActive(true);
        }
        if(Power == true)
        {
            _Power.SetActive(true);
            _PowerP.SetActive(false);
        }
        else
        {
            _Power.SetActive(false);
            _PowerP.SetActive(true);
        }
    }
}
