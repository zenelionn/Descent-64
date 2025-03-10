using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class enemyHealth : MonoBehaviour
{

    public static float health;
    public static Vector3 enemyDeathPos;
    public static Vector3 playerCutscene4Pos;
    public static Vector3 cameraCutscene4Pos;
    //public static Quaternion cameraCutscene4Rotation;

    [SerializeField] private GameObject enemy;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private GameObject deathFire;
    [SerializeField] private GameObject playerCutscenePos;
    [SerializeField] private GameObject cameraCutscenePos;

    

    [Header("Level Loader")]
    [SerializeField] private string levelToLoad;


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
            enemyDeathPos = enemy.transform.position;
            playerCutscene4Pos = playerCutscenePos.transform.position;
            cameraCutscene4Pos = cameraCutscenePos.transform.position;
            //cameraCutscene4Rotation = cameraCutscenePos.transform.rotation;
            StartCoroutine(killEnemy());        }
    }

    IEnumerator killEnemy(){
        yield return new WaitForSeconds(4);
        StartCoroutine(LoadLevelASync(levelToLoad));
        ///nemy.transform.position = new Vector3(-0.0140000004f,1.38800001f,-1140.69995f);
        //enemy.SetActive(false);
        //deathFire.SetActive(false);
    
    }

    IEnumerator LoadLevelASync(string levelToLoad){
        //modelChanger.Transformed = true;
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        yield return null;
   }
}
