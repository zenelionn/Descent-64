using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightfollow : MonoBehaviour
{
   [SerializeField] private GameObject player;
   [SerializeField] private GameObject playerLight;
   private Vector3 targetDestination;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //targetDestination = player.transform.position;
        playerLight.transform.position = player.transform.position;

    }
}
