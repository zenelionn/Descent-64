using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class candelPickup : MonoBehaviour
{
   [Header("Canvas Stuff")]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject EButton;
    [SerializeField] private GameObject player; 

    [Header("Candle Stuff")]
    private bool canInteract;
    private bool ammoTaken;
    [SerializeField] private GameObject candleStick;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

    void Start()
    {
        dialogueCanvas.enabled = false;
        canInteract = false;
        ammoTaken = false;
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
                if(ammoTaken != true){
                    if (modelChanger.Transformed == true){
                        dialogueText.SetText("Blunt force trauma... ironic isn't it?");
                        MagicBlastAttack.ammoAmount = MagicBlastAttack.ammoAmount + 1;
                        ammoTaken = true;
                    }
                    else{
                        dialogueText.SetText("We don't light this candle. Not anymore");
                    
                    }
                    dialogueCanvas.enabled = true;
                }
                

            }
        }
    }

}

