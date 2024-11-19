using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractiveRay : MonoBehaviour
{
    [SerializeField] private Transform grabPosition;
    [SerializeField] private GameObject Computer;

    private bool isGrab;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 5f);
        if (Physics.Raycast(ray, out hit, 5f))
        {
            if(isGrab == false && hit.collider.GetComponent<ComputerSettings>() && Input.GetKeyDown(KeyCode.E))
            {
                isGrab = true;
                Computer = hit.collider.GetComponent<ComputerSettings>().gameObject;
                Computer.GetComponent<BoxCollider>().enabled = false;
                Computer.transform.position = grabPosition.position;
                Computer.transform.SetParent(grabPosition);
            }
            if(isGrab == true && hit.collider.CompareTag("RepairTable") && Input.GetKeyDown(KeyCode.E))
            {
                GameObject repairTable = hit.collider.gameObject;
                Computer.GetComponent<BoxCollider>().enabled = true;
                Computer.transform.position = repairTable.transform.GetChild(3).position;
                Computer.transform.SetParent(repairTable.transform.GetChild(3));
                Computer = null;
                isGrab = false;
            }
        }
    }
}
