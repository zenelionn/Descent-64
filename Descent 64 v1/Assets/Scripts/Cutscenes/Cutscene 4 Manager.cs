using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Cutscene4Manager : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button skipButton;
    [SerializeField] private float typingSpeed = 0.05f;

    private bool isTyping = false;
    private Queue<string> sentences;

    [Header("Animations")]
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private List<string> playerAnimations = new List<string>();
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private List<string> enemyAnimations = new List<string>();

    [Header("Cameras")]
    [SerializeField] private List<Camera> cameraList = new List<Camera>();
    private Camera currentCamera;

    [Header("Positions")]
    //[SerializeField] private List<GameObject> positions = new List<GameObject>();
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject deathFire;
     
    [Header("Level Loader")]
    [SerializeField] private string levelToLoad;

    private int talkingTotal;
    private int shotNumber = 1;
    [SerializeField] private int shotTotal;

    void Start(){
        // initialise dialogue queue]
        talkingTotal = shotTotal +1;
        cameraList[0].transform.position = enemyHealth.cameraCutscene4Pos;
        cameraList[0].transform.rotation = enemyHealth.cameraCutscene4Rotation;
        cameraList[0].gameObject.SetActive(true);
        sentences = new Queue<string>();
        nextButton.onClick.AddListener(OnNextButtonClicked);
        skipButton.onClick.AddListener(SkipCutscene);
        nextButton.gameObject.SetActive(false);
        
        Enemy.transform.position = enemyHealth.enemyDeathPos;
        Player.transform.position = enemyHealth.playerCutscene4Pos;
        enemyAnimator.Play("death animation");
        deathFire.SetActive(true);
        
    }

    public void StartDialogue(Dialogue dialogue){
        sentences.Clear();
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(isTyping){
            return;
        }
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator TypeSentence(string sentence){
        dialogueText.text = ""; // clears current text
        isTyping = true;
        nextButton.gameObject.SetActive(false);

        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
        nextButton.gameObject.SetActive(true);
    }

    private void OnNextButtonClicked(){
        DisplayNextSentence();
        if (shotNumber != shotTotal){
            
            // player
            playerAnimator.Play(playerAnimations[shotNumber]);
            //Player.transform.position = positions[shotNumber].transform.position;
            //Player.transform.rotation = positions[shotNumber].transform.rotation;

            // enemy
            enemyAnimator.Play(enemyAnimations[shotNumber]);

            

            SwitchCameras(shotNumber);
            shotNumber = shotNumber + 1;
            Debug.Log(shotNumber);
 
        }
        else{
            shotNumber = shotTotal;
        }
        
    }

    private void EndDialogue(){
        Debug.Log("End of Dialogue");
        nextButton.gameObject.SetActive(false);
        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    private void SkipCutscene(){
        EndDialogue();
    }

    private void SwitchCameras(int shotNumber){
        foreach (Camera cam in cameraList){
            cam.gameObject.SetActive(false);
        }

        cameraList[shotNumber].gameObject.SetActive(true);
    }


    IEnumerator LoadLevelASync(string levelToLoad){
        modelChanger.Transformed = true;
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        yield return null;
   }
}
