using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBlastAttack : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Animator playerAnimation;
    [SerializeField] private GameObject player;
    private bool attacking;
    private int ammoAmount;

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

    void Start(){
        magicBall.SetActive(false);
        Cursor.lockState = CursorLockMode.None;

        // set despawn here

    }

    void Update(){
        finalDestination = enemy.transform.position;
        if (modelChanger.Transformed == true && Input.GetMouseButtonDown(1) && chaseState.isChasingCheck == false){
            StartCoroutine(endAttack());
            playerAnimation.SetBool("Attacking", true);
            // set location of magicball to player
            magicBall.transform.position = LocationOfTheBall.transform.position;
            
            magicBall.SetActive(true);
            attacking = true;
        }

        if (attacking == true){
            sendBall();
            // if ball touch man kill ball <3
            if (magicBall.transform.position == finalDestination){
                enemyHealth.health = enemyHealth.health - 1;
                magicBall.SetActive(false);
                magicBall.transform.position = player.transform.position;
            }
        }

    }

    IEnumerator endAttack(){
        
        yield return new WaitForSeconds(2);
        playerAnimation.SetBool("Attacking", false);
    }   

    void sendBall(){
        magicBall.transform.position = Vector3.MoveTowards(magicBall.transform.position, finalDestination, speed * Time.deltaTime);
        
    } 


}
