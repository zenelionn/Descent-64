using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Cutscene4Manager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button skipButton;
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private GameObject blackScreen;
    [SerializeField] private TMP_Text chokeText;


    private bool isTyping = false;
    
    private Queue<string> sentences;

    [Header("Audio")]
    [SerializeField] private AudioSource choking1;
    [SerializeField] private AudioSource choking2;
    [SerializeField] private AudioSource choking3;

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
    private int i = 0;
    [SerializeField] private int shotTotal;

    public static bool DavidDead = false;

    void Start(){
        talkingTotal = shotTotal +1;

        // initialising positions for everyone
        currentCamera = cameraList[0];
        cameraList[0].transform.position = enemyHealth.cameraCutscene4Pos + new Vector3(0,1,0);
        currentCamera.transform.LookAt(enemyHealth.playerCutscene4Pos);
        //cameraList[0].transform.rotation = enemyHealth.cameraCutscene4Rotation;
        cameraList[0].gameObject.SetActive(true);


        sentences = new Queue<string>();
        nextButton.onClick.AddListener(OnNextButtonClicked);
        skipButton.onClick.AddListener(SkipCutscene);
        nextButton.gameObject.SetActive(false);
        
        // initialising positions for enemy and player
        Enemy.transform.position = enemyHealth.enemyDeathPos;
        Player.transform.position = enemyHealth.playerCutscene4Pos;
        Player.transform.LookAt(enemyHealth.playerCutscene4Pos);

        //initialising player and enemy animations 
        playerAnimator.Play("Wary Idle");
        enemyAnimator.Play("death animation");
        deathFire.SetActive(true);

        
        blackScreen.SetActive(false);
        chokeText.enabled = false;
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

            if (shotNumber == 6){
                blackScreen.SetActive(true);
                choking1.Play();
            }
            if (shotNumber == 7){
                choking2.Play();
            }
            if (shotNumber == 8){
                choking3.Play();
            }

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
        DavidDead = true;
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        yield return null;
   }

    
   
}
