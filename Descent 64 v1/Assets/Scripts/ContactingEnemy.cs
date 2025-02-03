using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ContactingEnemy : MonoBehaviour
{

    // logic:
    // disable video player
    // if player is touching enemy enable video player
    // play jumpscare animation

    [SerializeField] private RawImage jumpscare;
    [SerializeField] private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        jumpscare.enabled = false;
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Enemy")){
            Debug.Log("Hit");
            jumpscare.enabled = true;
            videoPlayer.Play();
            
        }
    }
}
