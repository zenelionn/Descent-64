using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{

    /* Logic

    if press button
    - play animation
    - set magic ball location to players
    - enable magic ball
    - move magic ball towards enemy
    - set projectile after a few milliseconds to match animations
    */

    [SerializeField] private Animator playerAnimation;
    [SerializeField] private GameObject magicBall;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;  

    private Vector3 finalDestination;
    private bool attacking;
    private Vector3 despawn;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        magicBall.SetActive(false);
        despawn = new Vector3(-0.0140000004f,1.38800001f,-1140.69995f);
    }

    // Update is called once per frame
    void Update()
    {
        // move this back into the if statement if you want to add some sort of aiming mechanic
        finalDestination = enemy.transform.position;
        if (Input.GetKeyDown(KeyCode.B)){
            StartCoroutine(endAttack());
            playerAnimation.SetBool("Attacking", true);
            // set location of magicball to player
            magicBall.transform.position = player.transform.position;
            
            magicBall.SetActive(true);
            attacking = true;
            
        }
        if(attacking == true){
            sendBall();
            //if ball touch man kill ball
            if (magicBall.transform.position == finalDestination){
                enemyHealth.health = enemyHealth.health - 1;
                magicBall.SetActive(false);
                magicBall.transform.position = despawn;
                
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
