using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagnosticInteractiveRay : MonoBehaviour
{
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
    }
}
