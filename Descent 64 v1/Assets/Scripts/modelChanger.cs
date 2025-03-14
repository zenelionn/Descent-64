using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelChanger : MonoBehaviour
{
    public static bool Transformed = false;

    [SerializeField] private GameObject magicalGirl;
    [SerializeField] private GameObject normalGirl;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerPosAfterTransform;

    [SerializeField] private Light playerLight;

    [SerializeField] private Avatar magicalGirlAvatar;
    [SerializeField] private Avatar normalGirlAvatar;

    [SerializeField] private GameObject wholePlayer;

    private Animator animator;
    public AnimatorOverrideController magicalGirlController;
    

    


    


    void Start(){
        // set the player's animator as normal girl
        animator = GetComponent<Animator>();
        
        magicalGirl.SetActive(false);
        normalGirl.SetActive(true);
        playerLight.enabled = false;
        player.GetComponent<Animator>().avatar = normalGirlAvatar;
        
        if (Transformed == true){
            wholePlayer.transform.position = playerPosAfterTransform.transform.position;
            Debug.Log("Set player");
        }
        
    }

    void Update(){
        if (Transformed == true){
            // turn off normal girl

            normalGirl.SetActive(false);
            // change avatar
            player.GetComponent<Animator>().avatar = magicalGirlAvatar;
            animator.runtimeAnimatorController = magicalGirlController;
            // turn on magical girl
            magicalGirl.SetActive(true);
            // set position to the washroom

            // changing her speed
            
            
            playerLight.enabled = true;
        }
    }
}
