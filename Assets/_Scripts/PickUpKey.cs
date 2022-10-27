using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; 

public class PickUpKey : MonoBehaviour
{
    public GameObject DoorToUnlock;
    public Flowchart _flowchart; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorToUnlock.SetActive(false);
            // play collect effect, then destroy object, but this time we won't do this. 
            _flowchart.ExecuteBlock("Notify1"); 
            // play fungus Dialog
            gameObject.SetActive(false);
        }
    }
}
