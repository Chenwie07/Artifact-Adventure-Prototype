using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            PickUp pickUp = other.GetComponent<PickUp>();
            if (pickUp.Type == PickUp.PickUpEnum.Orb)
            {
                // call controller to update, but for illustration we shall do that here. 
                GameManager.Instance.UpdatePickUp();
                GameManager.Instance.AddTime(); 
                // play SFX 
                // play Collect Item Anim (shader graphs)
                // destroy object (in time with animation)
                Destroy(other.gameObject);
            }
        }
    }
}
