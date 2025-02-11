using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    private bool canInteract;
    private bool doorOpen;
    private Collider playerCollider;

    private void Start(){
        canInteract = false;
        //doorAnimator.SetBool("isOpen", false);
    }

    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Collider>() != null){
            playerCollider = other;
            canInteract = true;
            doorOpen = false;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other == playerCollider){
            canInteract = false;
            CloseDoor();
        }
        
    }

    private void Update(){
        if (canInteract && Input.GetKeyDown(interactionKey)){
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor(){
        if (doorAnimator != null){
            doorOpen = true;
            doorAnimator.Play("Door Open");

        }
    }

    private void CloseDoor(){
        if (doorOpen == true){
            doorAnimator.Play("Door Close");
            doorOpen = false;
        }
    }

    
    
}
