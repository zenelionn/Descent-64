using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class toolDIalogue : MonoBehaviour
{
    [Header("Canvas Stuff")]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject EButton;

    [Header("Tool Stuff")]
    private bool canInteract;
    [SerializeField] private GameObject tooltable;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private GameObject player; 

    void Start()
    {
        dialogueCanvas.enabled = false;
        canInteract = false;
        EButton.GetComponent<Image>().color = new Color32(70,70,70,255);
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject == player) {
            EButton.GetComponent<Image>().color = new Color32(255,255,255,255);
            canInteract = true;
        }

    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject == player) {
            EButton.GetComponent<Image>().color = new Color32(70,70,70,255);
            canInteract = false;
            dialogueCanvas.enabled = false;
        }
    }

    void Update(){
        if (canInteract && Input.GetKeyDown(interactionKey)){
            {
                dialogueText.SetText("dad likes his power tools");
                dialogueCanvas.enabled = true;

            }
        }
    }

}
