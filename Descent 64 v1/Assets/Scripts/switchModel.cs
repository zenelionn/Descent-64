using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchModel : MonoBehaviour
{
    private Avatar playerAvatar;
    [SerializeField] private Avatar model1;
    [SerializeField] private Avatar model2;
    [SerializeField] private GameObject MagicalGirl;
    [SerializeField] private GameObject NormalGirl;
    private Animator playerAnimator;

    void Start(){
        playerAnimator = GetComponent<Animator>(); // Get the Animator component
        playerAvatar = model1;
        playerAnimator.avatar = playerAvatar; // Set the initial Avatar for the Animator
        MagicalGirl.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.M)){
            if (playerAvatar == model1) {
                // Switch to model2
                playerAvatar = model2;
                NormalGirl.SetActive(false);
                MagicalGirl.SetActive(true);
            } else {
                // Switch back to model1
                playerAvatar = model1;
                NormalGirl.SetActive(true);
                MagicalGirl.SetActive(false);
            }

            playerAnimator.avatar = playerAvatar; // Update the Animator with the new Avatar
        }
    }
}
