using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class vasePickup : MonoBehaviour
{
    [Header("Canvas Stuff")]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject EButton;

    [Header("Vase Stuff")]
    private bool canInteract;
    public static bool ammoTaken;
    [SerializeField] private GameObject vase;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;


    // no sound yet but maybe a sound when picked up?

    void Start()
    {
        dialogueCanvas.enabled = false;
        canInteract = false;
        ammoTaken = false;
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
                if (ammoTaken != true){
                    if (modelChanger.Transformed == true){
                    dialogueText.SetText("This is one of the last vases after Dad broke them all.");
                    MagicBlastAttack.ammoAmount = MagicBlastAttack.ammoAmount + 1;
                    ammoTaken = true;
                
                    }
                    else{
                    dialogueText.SetText("is it pronounced vase or vase?");
                    
                    }
                    dialogueCanvas.enabled = true;
                    //Debug.Log(MagicBlastAttack.ammoAmount);
                }
                
            
                
                

            }
    }}
}
