using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    public static float health;
    [SerializeField] private Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;   
        enemyAnimator.SetBool("isDying", false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1){
            enemyAnimator.SetBool("isDying", true);
        }
    }
}
