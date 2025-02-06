using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class enemyHealth : MonoBehaviour
{

    public static float health;

    [SerializeField] private GameObject enemy;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private GameObject deathFire;


    // Start is called before the first frame update
    void Start()
    {
        health = 3;   
        enemyAnimator.SetBool("isDying", false); 
        deathFire.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        deathFire.transform.position = enemy.transform.position;
        if (health < 1){
            enemyAnimator.SetBool("isDying", true);
            deathFire.SetActive(true);
            StartCoroutine(killEnemy());        }
    }

    IEnumerator killEnemy(){
        yield return new WaitForSeconds(4);
        enemy.transform.position = new Vector3(-0.0140000004f,1.38800001f,-1140.69995f);
        enemy.SetActive(false);
        deathFire.SetActive(false);
    
    }
}
