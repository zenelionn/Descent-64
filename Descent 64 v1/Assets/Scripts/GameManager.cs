using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /* -- Logic --

    Objects to take in:
    - player's collider
    - enemy's collider
    - canvas

    x - in our start function we disable to canvas 
    - in our update function we are testing to see if the player's collider touches the enemy's collider
    - when it does, we enable the canvas and play the jumpscare animation
    - after the video ends, we take them to a new scene for a death screen

    */ 

    [SerializeField] private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;        
    }

    void OnTriggerEnter(Collider collision){
        // change text
        if (collision.gameObject.CompareTag("Enemy")){
            Debug.Log("hitting");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
