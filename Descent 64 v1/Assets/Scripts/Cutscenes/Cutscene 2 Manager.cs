using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cutscene2Manager : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Canvas dialogueCanvas;
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
    [SerializeField] private List<GameObject> positions = new List<GameObject>();
    [SerializeField] private GameObject Player;
    
    [Header("Level Loader")]
    [SerializeField] private string levelToLoad;

    [Header("Video Player")]
    [SerializeField] private Canvas transformCanvas;
    [SerializeField] private VideoPlayer videoplayer;

    [Header("Light")]
    [SerializeField] private Light brightLight;

    [Header("Sound")]
    [SerializeField] private AudioSource backgroundMusic;



    private int talkingTotal;
    private int shotNumber = 1;
    [SerializeField] private int shotTotal;

    void Start(){
        // background music
        backgroundMusic.Play();

        brightLight.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // initialise dialogue queue]
        talkingTotal = shotTotal +1;
        transformCanvas.enabled = false;
        dialogueCanvas.enabled = true;
        //cameraList[0].gameObject.SetActive(true);
        sentences = new Queue<string>();

        playerAnimator.Play(playerAnimations[0]);
        nextButton.onClick.AddListener(OnNextButtonClicked);
        skipButton.onClick.AddListener(SkipCutscene);
        nextButton.gameObject.SetActive(false);
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
            playerAnimator.Play(playerAnimations[shotNumber]);
            Player.transform.position = positions[shotNumber].transform.position;
            Player.transform.rotation = positions[shotNumber].transform.rotation;
            enemyAnimator.Play(enemyAnimations[shotNumber]);
            SwitchCameras(shotNumber);
            shotNumber = shotNumber + 1;
            Debug.Log(shotNumber);

            //light
            if (shotNumber == 4){
                brightLight.enabled = true;
            }

        }
        else{
            shotNumber = shotTotal;
        }
        
    }

    private void EndDialogue(){
        Debug.Log("End of Dialogue");
        nextButton.gameObject.SetActive(false);
        PlayTransformation();
        
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

    private void PlayTransformation(){
        transformCanvas.enabled = true;
        dialogueCanvas.enabled = false;
        // turn background music off
        backgroundMusic.Stop();
        videoplayer.Play();
    }

    IEnumerator LoadLevelASync(string levelToLoad){
        yield return new WaitForSeconds(18);
        modelChanger.Transformed = true;
        transformCanvas.enabled = false;
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        yield return null;
   }


   
   
}
