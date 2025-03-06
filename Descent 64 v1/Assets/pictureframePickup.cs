using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class pictureframePickup : MonoBehaviour
{
    [Header("Canvas Stuff")]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject EButton;

    [Header("Picture Stuff")]
    private bool canInteract;
    [SerializeField] private GameObject pictureFrame;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

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
                    dialogueText.SetText("A memory of a happier day... yeah right");
                    MagicBlastAttack.ammoAmount = MagicBlastAttack.ammoAmount + 1;
                }
                else{
                    dialogueText.SetText("The family portrait!");
                    
                }
                dialogueCanvas.enabled = true;

            }
        }
    }
}
