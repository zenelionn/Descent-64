using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour
{
    [Header("Door Stuff")]
    [SerializeField] private GameObject door;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private bool washroom;
    private bool canInteract;
    private bool doorOpen;
    [SerializeField] private GameObject player; 

    public static bool isLocked = true;

    [Header("Canvas Stuff")]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject EButton;

    [Header("Sound Stuff")]
    [SerializeField] private AudioSource doorOpenSound;
    [SerializeField] private AudioSource doorCloseSound;
    [SerializeField] private AudioSource lockedDoor;

    private void Start(){
        canInteract = false;
        dialogueCanvas.enabled = false;
        EButton.GetComponent<Image>().color = new Color32(70,70,70,255);
    }

    private void OnTriggerEnter(Collider other){
        
        if (other.gameObject == player) {
            EButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            canInteract = true;
            doorOpen = false;
        }
    }

    private void OnTriggerExit(Collider other){
        
        if (other.gameObject == player) {
            canInteract = false;
            CloseDoor();
            dialogueCanvas.enabled = false;
            EButton.GetComponent<Image>().color = new Color32(70, 70, 70, 255);
        }
    }

    private void Update(){
        if (canInteract && Input.GetKeyDown(interactionKey)){
            if (washroom == true && isLocked == true && modelChanger.Transformed == false){
                dialogueText.SetText("It's locked");
                lockedDoor.Play();
                dialogueCanvas.enabled = true;
            }
            else{
                OpenDoor();
            }
        }
    }

    private void OpenDoor(){
        if (doorAnimator != null){
            doorOpen = true;
            doorAnimator.Play("Door Open");
            doorOpenSound.Play();
        }
    }

    private void CloseDoor(){
        if (doorOpen == true){
            doorAnimator.Play("Door Close");
            doorOpen = false;
            doorCloseSound.Play();
        }
    }
}
