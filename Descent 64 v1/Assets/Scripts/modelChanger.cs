using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelChanger : MonoBehaviour
{

    // Model changing
    [SerializeField] private Avatar magicGirl;
    [SerializeField] private GameObject magicGirlBody;
    [SerializeField] private Light magicGirlLight;
    [SerializeField] private Avatar normalGirl;
    [SerializeField] private Avatar player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = normalGirl;
        magicGirlBody.SetActive(false);
        magicGirlLight.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
