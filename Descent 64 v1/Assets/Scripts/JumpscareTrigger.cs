using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class JumpscareTrigger : MonoBehaviour
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private VideoPlayer videoplayer;

    void Start(){
        canvas.enabled = false;
    }
    void Update(){
        if (chaseState.jumpscareCheck == true){
            canvas.enabled = true;
            videoplayer.Play();
        }
    }
}
