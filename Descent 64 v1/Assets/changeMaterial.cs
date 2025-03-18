using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMaterial : MonoBehaviour
{
    [SerializeField] Texture2D cleanTexture;
    [SerializeField] Texture2D messyTexture;
    [SerializeField] Material magicalGirlMaterial;


    // Start is called before the first frame update
    void Start()
    {
        magicalGirlMaterial.SetTexture("_BaseMap",cleanTexture);

    }

    // Update is called once per frame
    void Update()
    {
        if(Cutscene4Manager.DavidDead == true){
            magicalGirlMaterial.SetTexture("_BaseMap",messyTexture);
        }
    }
}
