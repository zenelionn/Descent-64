using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class chaseChange : MonoBehaviour
{
    [Header("Post Processing Settings")]
    [SerializeField] private Volume postProcessVolume;  
    [SerializeField] private VolumeProfile profile1;  
    [SerializeField] private VolumeProfile profile2; 
    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume.profile = profile1;
    }

    // Update is called once per frame
    void Update()
    {
        if (chaseState.isChasingCheck == true){
            postProcessVolume.profile = profile2;
        }
        if (chaseState.isChasingCheck == false){
            postProcessVolume.profile = profile1;
        }
        
    
    }
}
