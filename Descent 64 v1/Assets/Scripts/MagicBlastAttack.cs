using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MagicBlastAttack : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Animator playerAnimation;
    [SerializeField] private GameObject player;
    private bool attacking;
    public static int ammoAmount;

    [Header("MagicBall")]
    [SerializeField] private GameObject magicBall;
    [SerializeField] private GameObject LocationOfTheBall;
    [SerializeField] private float speed;
    private Vector3 finalDestination;
    private Vector3 despawn;

    [Header("Enemy")]
    [SerializeField] private GameObject enemy;

    [Header("Canvas Stuff")]
    [SerializeField] private GameObject AttackButton;
    [SerializeField] private GameObject AmmoParent;
    [SerializeField] private GameObject AmmoBtn1;
    [SerializeField] private GameObject AmmoBtn2;
    [SerializeField] private GameObject AmmoBtn3;
    

    void Start(){
        // ammo UI
        AmmoParent.SetActive(false);
        AmmoBtn1.GetComponent<Image>().color = new Color32(103,103,103,255);
        AmmoBtn2.GetComponent<Image>().color = new Color32(103,103,103,255);
        AmmoBtn2.GetComponent<Image>().color = new Color32(103,103,103,255);

        magicBall.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        AttackButton.GetComponent<Image>().color = new Color32(70,70,70,255);

        // set despawn here

    }

    void Update(){
        if (modelChanger.Transformed == true){
            AmmoParent.SetActive(true);
        }
        if (enemy != null){
            finalDestination = enemy.transform.position;
        }
        
        // button
        if (ammoAmount > 0){
            AttackButton.GetComponent<Image>().color = new Color32(255,255,255,255);
        
        }
        if (ammoAmount == 0){
            AttackButton.GetComponent<Image>().color = new Color32(70,70,70,255);
            AmmoBtn1.GetComponent<Image>().color = new Color32(103,103,103,255);
        }
        if (ammoAmount == 1){
            AmmoBtn1.GetComponent<Image>().color = new Color32(255,255,255,255);
            AmmoBtn2.GetComponent<Image>().color = new Color32(103,103,103,255);
            AmmoBtn3.GetComponent<Image>().color = new Color32(103,103,103,255);
        }
        if (ammoAmount == 2){
            AmmoBtn2.GetComponent<Image>().color = new Color32(255,255,255,255);
            AmmoBtn3.GetComponent<Image>().color = new Color32(103,103,103,255);
        }
        if (ammoAmount == 3){
            AmmoBtn3.GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        if (modelChanger.Transformed == true && Input.GetMouseButtonDown(1) && chaseState.isChasingCheck == false && ammoAmount > 0){
            StartCoroutine(endAttack());
            playerAnimation.SetBool("Attacking", true);
            // set location of magicball to player
            magicBall.transform.position = LocationOfTheBall.transform.position;
            
            magicBall.SetActive(true);
            attacking = true;
            ammoAmount = ammoAmount - 1;
            
        }

        if (attacking == true){
            sendBall();
            // if ball touch man kill ball <3
            if (magicBall.transform.position == finalDestination){
                
                magicBall.SetActive(false);
                magicBall.transform.position = player.transform.position;
                
            }
        }

       

    }

    IEnumerator endAttack(){
        
        yield return new WaitForSeconds(2);
        playerAnimation.SetBool("Attacking", false);
        enemyHealth.health = enemyHealth.health - 1;
    }   

    void sendBall(){
        magicBall.transform.position = Vector3.MoveTowards(magicBall.transform.position, finalDestination, speed * Time.deltaTime);
        
    } 


}
