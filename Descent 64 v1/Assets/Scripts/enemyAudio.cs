using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAudio : MonoBehaviour
{
    [SerializeField] private AudioSource crawlingSource;
    [SerializeField] private AudioSource chasingSource;

    private bool hasPlayedChasingSound = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (patrolState.isMoving)
        {
           
            if (!crawlingSource.isPlaying) 
            {
                crawlingSource.Play();
            }
        }

        
        if (chaseState.isChasingCheck)
        {
           
            if (!hasPlayedChasingSound)
            {
                chasingSource.Play();
                hasPlayedChasingSound = true; 
            }

           
            chasingSource.pitch = 1.2f; 
        }
        else
        {
            
            if (chasingSource.isPlaying)
            {
                chasingSource.Stop();
                hasPlayedChasingSound = false; 
            }

           
            chasingSource.pitch = 1f;
        }

         

         if(chaseState.jumpscareCheck == true){
            chasingSource.Stop();
            crawlingSource.Stop();
         }
            
    }

   
    
}
