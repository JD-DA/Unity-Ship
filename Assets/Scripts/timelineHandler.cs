using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timelineHandler : MonoBehaviour
{
    public static timelineHandler Instance;
    
    //indice que l'on va changer au fur et à mesure du jeu
    public int rare = 10;
    public int common = 1;
    public int quiterare = 5;
    public int sparkling = 2;

    public int numAsteroid = 6;
    public int numBigAsteroid = 7;
    
    void Start()
    {
        if(Instance == null){
            Instance = this;
        }else if (this != Instance){
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        
    }
}
