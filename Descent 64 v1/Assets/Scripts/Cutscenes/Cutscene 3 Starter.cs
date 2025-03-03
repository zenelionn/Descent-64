using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cutscene3Starter : MonoBehaviour
{
    public Cutscene3Manager dialogueManager;
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
