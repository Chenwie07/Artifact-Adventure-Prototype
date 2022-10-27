using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalColliderScaler : StateMachineBehaviour
{
    private CharacterController characterController;
    [Header("Character Collider Modified fields")]
    [SerializeField] float _height; 
    [SerializeField] Vector3 _colliderCenter;
    [SerializeField] float _radius; 




    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        characterController = FindObjectOfType<CharacterController>();
        // reduce the height of the collider when you enter this state. 
        characterController.height = _height;
        //Debug.Log(_colliderCenter.y);
        characterController.center = _colliderCenter;
        //Debug.Log(characterController.center.y); 
        characterController.radius = _radius;
    }
}
