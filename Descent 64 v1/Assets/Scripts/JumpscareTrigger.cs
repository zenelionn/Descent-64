using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class JumpscareTrigger : MonoBehaviour
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private VideoPlayer videoplayer;

    void Start(){
        canvas.enabled = false;
        
    }
    void Update(){
        if (chaseState.jumpscareCheck == true){
            StartCoroutine(endVideo());
            canvas.enabled = true;
            videoplayer.Play();
        }
    }

    IEnumerator endVideo(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Death Screen");
    }
    
}
