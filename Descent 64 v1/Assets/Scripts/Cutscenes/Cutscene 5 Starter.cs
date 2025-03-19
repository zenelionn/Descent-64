using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cutscene5Starter : MonoBehaviour
{
    public Cutscene5Manager dialogueManager;
    public Dialogue dialogue;
    [SerializeField] private Button startButton;
    // Start is called before the first frame update
    private void Start(){
        startButton.onClick.AddListener(StartCutscene);
    }

    public void StartCutscene(){
        startButton.gameObject.SetActive(false);
        dialogueManager.StartDialogue(dialogue);

    }
}
