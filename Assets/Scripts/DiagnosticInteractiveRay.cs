using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagnosticInteractiveRay : MonoBehaviour
{
    [SerializeField] private GameObject virtualCameraPlayer;
    [SerializeField] private GameObject cameraPlayer;
    [SerializeField] private GameObject thisDiagnostic;
    [SerializeField] private GameObject Player;

    public GameObject _Computer;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }
    private void Interact()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject _invetorySystem = FindObjectOfType<InventorySystem>().gameObject;
            if(_invetorySystem.GetComponent<InventorySystem>().items.Count != 6)
            {
                if (hit.collider.CompareTag("GPU"))
                {
                    _Computer.GetComponent<ComputerSettings>().GPU = false;
                    _Computer.GetComponent<ComputerSettings>().PCstat();
                    GameObject invetorySystem = FindObjectOfType<InventorySystem>().gameObject;
                    invetorySystem.GetComponent<InventorySystem>().addItem(3);
                }
                if (hit.collider.CompareTag("CPU"))
                {
                    _Computer.GetComponent<ComputerSettings>().CPU = false;
                    _Computer.GetComponent<ComputerSettings>().PCstat();
                    GameObject invetorySystem = FindObjectOfType<InventorySystem>().gameObject;
                    invetorySystem.GetComponent<InventorySystem>().addItem(2);
                }
                if (hit.collider.CompareTag("RAM1"))
                {
                    _Computer.GetComponent<ComputerSettings>().RAM1 = false;
                    _Computer.GetComponent<ComputerSettings>().PCstat();
                    GameObject invetorySystem = FindObjectOfType<InventorySystem>().gameObject;
                    invetorySystem.GetComponent<InventorySystem>().addItem(1);
                }
                if (hit.collider.CompareTag("RAM2"))
                {
                    _Computer.GetComponent<ComputerSettings>().RAM2 = false;
                    GameObject invetorySystem = FindObjectOfType<InventorySystem>().gameObject;
                    invetorySystem.GetComponent<InventorySystem>().addItem(1);
                    _Computer.GetComponent<ComputerSettings>().PCstat();
                }
                if (hit.collider.CompareTag("Power"))
                {
                    _Computer.GetComponent<ComputerSettings>().Power = false;
                    _Computer.GetComponent<ComputerSettings>().PCstat();
                    GameObject invetorySystem = FindObjectOfType<InventorySystem>().gameObject;
                    invetorySystem.GetComponent<InventorySystem>().addItem(4);
                }
                if (hit.collider.CompareTag("Cooler"))
                {
                    _Computer.GetComponent<ComputerSettings>().Cooler = false;
                    _Computer.GetComponent<ComputerSettings>().PCstat();
                    GameObject invetorySystem = FindObjectOfType<InventorySystem>().gameObject;
                    invetorySystem.GetComponent<InventorySystem>().addItem(5);
                }

            }

            if (hit.collider.CompareTag("GPUP"))
            {
                var items = Object.FindObjectsOfType<item>();
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetComponent<item>().select == true && items[i].GetComponent<item>().itemID == 3)
                    {
                        Remover(3);
                        _Computer.GetComponent<ComputerSettings>().GPU = true;
                        _Computer.GetComponent<ComputerSettings>().PCstat();
                    }
                }
            }
            if (hit.collider.CompareTag("CPUP"))
            {
                var items = Object.FindObjectsOfType<item>();
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetComponent<item>().select == true && items[i].GetComponent<item>().itemID == 2)
                    {
                        Remover(2);
                        _Computer.GetComponent<ComputerSettings>().CPU = true;
                        _Computer.GetComponent<ComputerSettings>().PCstat();
                    }
                }
            }
            if (hit.collider.CompareTag("RAM1P"))
            {
                var items = Object.FindObjectsOfType<item>();
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetComponent<item>().select == true && items[i].GetComponent<item>().itemID == 1)
                    {
                        Remover(1);
                        _Computer.GetComponent<ComputerSettings>().RAM1 = true;
                        _Computer.GetComponent<ComputerSettings>().PCstat();
                    }
                }
            }
            if (hit.collider.CompareTag("RAM2P"))
            {
                var items = Object.FindObjectsOfType<item>();
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetComponent<item>().select == true && items[i].GetComponent<item>().itemID == 1)
                    {
                        Remover(1);
                        _Computer.GetComponent<ComputerSettings>().RAM2 = true;
                        _Computer.GetComponent<ComputerSettings>().PCstat();
                    }
                }
            }
            if (hit.collider.CompareTag("PowerP"))
            {
                var items = Object.FindObjectsOfType<item>();
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetComponent<item>().select == true && items[i].GetComponent<item>().itemID == 4)
                    {
                        Remover(4);
                        _Computer.GetComponent<ComputerSettings>().Power = true;
                        _Computer.GetComponent<ComputerSettings>().PCstat();
                    }
                }
            }
            if (hit.collider.CompareTag("CoolerP"))
            {
                var items = Object.FindObjectsOfType<item>();
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetComponent<item>().select == true && items[i].GetComponent<item>().itemID == 5)
                    {
                        Remover(5);
                        _Computer.GetComponent<ComputerSettings>().Cooler = true;
                        _Computer.GetComponent<ComputerSettings>().PCstat();
                    }
                }
            }
        }
    }
    public void Back()
    {
        Cursor.visible = false;
        var Computer = Object.FindObjectsOfType<ComputerSettings>();
        for (int i = 0; i < Computer.Length; i++)
        {
            Computer[i].GetComponent<BoxCollider>().enabled = true;
        }
        virtualCameraPlayer.SetActive(true);
        Invoke("PlayerOn", 1f);
    }
    public void Get()
    {
        var Computer = Object.FindObjectsOfType<ComputerSettings>();
        for(int i = 0; i < Computer.Length; i++ )
        {
            Computer[i].GetComponent<ComputerSettings>().isRepairTable = false;
            Computer[i].GetComponent<BoxCollider>().enabled = true;
        }
        Cursor.visible = false;
        virtualCameraPlayer.SetActive(true);
        Invoke("PlayerOn", 1f);
    }
    private void PlayerOn()
    {
        Player.SetActive(true);
        cameraPlayer.SetActive(false);
        virtualCameraPlayer.SetActive(true);
        thisDiagnostic.SetActive(false);
    }
    private void Remover(int id)
    {
        GameObject _invetorySystemRemover = FindObjectOfType<InventorySystem>().gameObject;
        _invetorySystemRemover.GetComponent<InventorySystem>().removeItem(id);
    }
}
