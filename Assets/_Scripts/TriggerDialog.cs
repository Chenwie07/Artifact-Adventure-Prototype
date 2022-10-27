using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; 

public class TriggerDialog : MonoBehaviour
{
    [SerializeField] Flowchart _fungusFlowchart;
    [SerializeField] string _dialogBlockName; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Triggering The dialog"); 
            _fungusFlowchart.ExecuteBlock(_dialogBlockName);         }
    }
}
