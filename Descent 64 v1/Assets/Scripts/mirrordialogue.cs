using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class mirrordialogue : MonoBehaviour
{
    [Header("Canvas Stuff")]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject EButton;

    [Header("Vase Stuff")]
    private bool canInteract;
    [SerializeField] private GameObject mirror;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;


    // no sound yet but maybe a sound when picked up?

    void Start()
    {
        dialogueCanvas.enabled = false;
        canInteract = false;
        EButton.GetComponent<Image>().color = new Color32(70,70,70,255);
    }

    private void OnTriggerEnter(Collider other){
        EButton.GetComponent<Image>().color = new Color32(255,255,255,255);
        canInteract = true;

    }

    private void OnTriggerExit(Collider other){
        EButton.GetComponent<Image>().color = new Color32(70,70,70,255);
        canInteract = false;
        dialogueCanvas.enabled = false;
    }

    void Update(){
        if (canInteract && Input.GetKeyDown(interactionKey)){
            {
                if (modelChanger.Transformed == true){
                    dialogueText.SetText("I look... incredible!");
                }
                else{
                    dialogueText.SetText("I don't like my reflection");
                    
                }
                dialogueCanvas.enabled = true;

            }
    }}
}
