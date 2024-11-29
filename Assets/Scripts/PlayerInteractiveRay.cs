using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractiveRay : MonoBehaviour
{
    [SerializeField] private Transform grabPosition;

    [SerializeField] private GameObject clueForE;
    [SerializeField] private GameObject diagnosticInterface;
    [SerializeField] private GameObject _Camera;
    [SerializeField] private GameObject virtualCamera;
    [SerializeField] private GameObject infoCanvas;
    [SerializeField] private AudioSource GrabAudio, PutAudio, InfoAudio;

    private bool InfCan;

    private GameObject Computer;
    private bool isGrab;

    private void Start()
    {
        diagnosticInterface.SetActive(false);
        _Camera.SetActive(false);
        virtualCamera.SetActive(true);
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 2f);
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.gameObject.CompareTag("Info") && InfCan == false)
            {
                clueForE.SetActive(true);
                if (hit.collider.gameObject.CompareTag("Info") && Input.GetKeyDown(KeyCode.E))
                {
                    InfoAudio.Play();
                    GameObject player = FindObjectOfType<FirstPersonController>().gameObject;
                    player.GetComponent<FirstPersonController>().enabled = false;
                    ShowC();
                    infoCanvas.SetActive(true);
                    InfCan = true;
                }
            }
            else
            {
                clueForE.SetActive(false);
            }
            if(hit.collider.GetComponent<ComputerSettings>() && Computer == null)
            {
                clueForE.SetActive(true);
                if (Computer == null && Input.GetKeyDown(KeyCode.E))
                {
                    isGrab = false;
                }
                if (isGrab == false && hit.collider.GetComponent<ComputerSettings>().isRepairTable == false && Input.GetKeyDown(KeyCode.E))
                {
                    GrabAudio.Play();
                    isGrab = true;
                    Computer = hit.collider.GetComponent<ComputerSettings>().gameObject;
                    GameObject table = FindObjectOfType<TableControl>().gameObject;
                    table.GetComponent<TableControl>().Put(Computer.GetComponent<ComputerSettings>().placeNumber);
                    Computer.GetComponent<BoxCollider>().enabled = false;
                    Computer.transform.position = grabPosition.position;
                    Computer.transform.rotation = grabPosition.rotation;
                    Computer.transform.SetParent(grabPosition);
                }
            }
            if(hit.collider.CompareTag("RepairTable") && Computer != null)
            {
                clueForE.SetActive(true);
                if (isGrab == true && hit.collider.CompareTag("RepairTable") && Input.GetKeyDown(KeyCode.E))
                {
                    PutAudio.Play();
                    GameObject repairTable = hit.collider.gameObject;
                    Computer.GetComponent<ComputerSettings>().isRepairTable = true;
                    Computer.GetComponent<BoxCollider>().enabled = true;
                    Computer.transform.position = repairTable.transform.GetChild(3).position;
                    Computer.transform.rotation = repairTable.transform.GetChild(3).rotation;
                    Computer.transform.SetParent(repairTable.transform.GetChild(3));
                    Computer = null;
                    isGrab = false;
                }
            }
            if (hit.collider.GetComponent<TableControl>() && Computer != null)
            {
                clueForE.SetActive(true);
                if (isGrab == true && hit.collider.GetComponent<TableControl>() && Input.GetKeyDown(KeyCode.E))
                {
                    PutAudio.Play();
                    GameObject table = hit.collider.GetComponent<TableControl>().gameObject;
                    table.GetComponent<TableControl>().Take(Computer);
                    Computer.GetComponent<BoxCollider>().enabled = true;
                    Computer = null;
                    isGrab = false; 
                }
            }
            if (isGrab == false && hit.collider.GetComponent<ComputerSettings>().isRepairTable == true && Input.GetKeyDown(KeyCode.E)) 
            {
                Computer = hit.collider.gameObject;
                Computer.GetComponent<BoxCollider>().enabled = false;
                Invoke("PlayerOff", 0.1f);
                MoveVirtualCamera();
            }
            if (hit.collider.GetComponent<ReadyPC>() && Computer != null)
            {
                Debug.Log(clueForE);
                clueForE.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject RPc = hit.collider.GetComponent<ReadyPC>().gameObject;
                    RPc.GetComponent<ReadyPC>().CheckPC(Computer);
                }

            }
        }
        else
        {
            clueForE.SetActive(false);
        }
    }
    private void MoveVirtualCamera()
    {
        GameObject PlayerCamera = GameObject.FindWithTag("MainCamera");
        virtualCamera.transform.position = PlayerCamera.transform.position;
        virtualCamera.transform.rotation = PlayerCamera.transform.rotation;
        _Camera.SetActive(true);
    }
    private void PlayerOff()
    {
        clueForE.SetActive(false);
        virtualCamera.SetActive(false);
        diagnosticInterface.SetActive(true);
        GameObject diagnosticPlayer = Object.FindObjectOfType<DiagnosticInteractiveRay>().gameObject;
        diagnosticPlayer.GetComponent<DiagnosticInteractiveRay>()._Computer = Computer;
        Computer = null;
        GameObject Player = GameObject.FindWithTag("Player");
        ShowC();
        Player.SetActive(false);
    }
    public void BackInfo()
    {
        GameObject player = FindObjectOfType<FirstPersonController>().gameObject;
        player.GetComponent<FirstPersonController>().enabled = true;
        infoCanvas.SetActive(false);
        InfCan = false;
        HideC();
    }
    private void ShowC()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void HideC()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
