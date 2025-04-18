using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class bookshelf2dialogue : MonoBehaviour
{
    [Header("Canvas Stuff")]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject EButton;

    [Header("bookshelf Stuff")]
    private bool canInteract;
    [SerializeField] private GameObject bookshelf;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private GameObject player; 


    // no sound yet but maybe a sound when picked up?

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
                dialogueText.SetText("dad says a proper house should have books");
                dialogueCanvas.enabled = true;

            }
    }}
}
