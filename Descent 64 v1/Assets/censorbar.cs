using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class censorbar : MonoBehaviour
{

    // set enemy pos to cutscene 4 death pos

    // have the censor bar always be looking at the player to hide the body


    [SerializeField] private GameObject enemy;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private GameObject censorBar;
    [SerializeField] private Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        //enemy.transform.position = enemyHealth.enemyDeathPos;
        if (Cutscene4Manager.DavidDead == false){
            censorBar.SetActive(false);
        }
        else{
            Destroy(enemy);
            censorBar.SetActive(true);
            censorBar.transform.position = enemyHealth.enemyDeathPos;
            //enemyAnimator.SetBool("isDying", false);
            //enemy.SetActive(false);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        censorBar.transform.LookAt(playerCam.transform.position);
    }
}
