using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singletonSounds : MonoBehaviour
{
    //Used in all the scenes differents from the play infinite one
    public static singletonSounds Instance;
    void Start()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(Instance.gameObject);
        }else if (this != Instance){
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
