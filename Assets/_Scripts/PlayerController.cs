using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // pass animations the usual way and trigger them. 

    private Animator _animator;
    private CharacterController characterController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        characterController = FindObjectOfType<CharacterController>();
    }

    public void TriggerRoll()
    {
        _animator.SetTrigger("Slide"); 
    }
}
