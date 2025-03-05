using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class collectKey : MonoBehaviour
{

    // if player collides with the key
    // press E get's highlighted
    // when E is pressed pop up dialogue box saying
    // it's a key. I wonder what it leads to?
    // Start is called before the first frame update

    [Header("Canvas Stuff")]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject EButton;

    [Header("Key Stuff")]
    private bool canInteractWithKey;
    [SerializeField] private GameObject key;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    private bool KeyTaken;

    [Header("Sound Stuff")]
    [SerializeField] private AudioSource keyNoise;
    
    
    void Start()
    {
        dialogueCanvas.enabled = false;
        canInteractWithKey = false;
        EButton.GetComponent<Image>().color = new Color32(70,70,70,255);
    }

    private void OnTriggerEnter(Collider other){
        
        if (KeyTaken){
            canInteractWithKey = false;
        }
        else{
            canInteractWithKey = true;
            EButton.GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        


    }

    private void OnTriggerExit(Collider other){
        EButton.GetComponent<Image>().color = new Color32(70,70,70,255);
        canInteractWithKey = false;
        dialogueCanvas.enabled = false;
    }

    void Update(){
        if (canInteractWithKey && Input.GetKeyDown(interactionKey)){
            {
                keyNoise.Play();
                dialogueText.SetText("it's a key. I wonder what it leads to?");
                DoorManager.isLocked = false;
                dialogueCanvas.enabled = true;
                key.SetActive(false);
                KeyTaken = true;

            }
        }

        if (modelChanger.Transformed == true){
            key.SetActive(false);
            KeyTaken = true;
        }
    }

}
