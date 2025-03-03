using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusicController : MonoBehaviour
{

    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource chaseMusic;

    // Start is called before the first frame update
    void Awake()
    {
        backgroundMusic.Play();
        // set chase music to 0 volume
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!chaseState.isChasingCheck){
            chaseMusic.Play();

        }
        
    }
}
