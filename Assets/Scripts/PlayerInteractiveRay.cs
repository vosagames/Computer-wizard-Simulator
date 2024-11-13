using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractiveRay : MonoBehaviour
{
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 5f);
        if (Physics.Raycast(ray, out hit, 5f))
        {
            
        }
    }
}
