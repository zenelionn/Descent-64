using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class censorbar : MonoBehaviour
{

    // set enemy pos to cutscene 4 death pos

    // have the censor bar always be looking at the player to hide the body
    [Header("Canvas Stuff")]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject EButton;

    [Header("Interacting with the Censor")]
    private bool canInteract;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

    [SerializeField] private GameObject enemy;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private GameObject censorBar;
    [SerializeField] private Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas.enabled = false;
        canInteract = false;
        EButton.GetComponent<Image>().color = new Color32(70,70,70,255);

        //enemy.transform.position = enemyHealth.enemyDeathPos;
        if (Cutscene4Manager.DavidDead == false){
            censorBar.SetActive(false);
        }
        else{
            Destroy(enemy);
            censorBar.SetActive(true);
            censorBar.transform.position = enemyHealth.enemyDeathPos;
            //enemyAnimator.SetBool("isDying", false);
            //enemy.SetActive(false);
        }

        
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

    // Update is called once per frame
    void Update()
    {
        censorBar.transform.LookAt(playerCam.transform.position);

        if (canInteract && Input.GetKeyDown(interactionKey)){
            dialogueText.SetText("I can't look at him...");
            dialogueCanvas.enabled = true;
        }
        
    }
}
