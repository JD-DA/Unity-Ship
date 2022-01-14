using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton : MonoBehaviour
{
    public static singleton Instance;
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
