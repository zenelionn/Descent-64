using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{

    /* Logic

    if press button
    - play animation
    - set projectile after a few milliseconds to match animations
    */

    [SerializeField] private Animator playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)){
            StartCoroutine(endAttack());
            Debug.Log("Attack");
            playerAnimation.SetBool("Attacking", true);
        }
    }

    IEnumerator endAttack(){
        
        yield return new WaitForSeconds(2);
        playerAnimation.SetBool("Attacking", false);
    }
}
