using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timelineHandler : MonoBehaviour
{
    public static timelineHandler Instance;
    
    //indice de rareté, on va multiplier ce nombre par le fps pour générer avec une même cadence approximative selon l'appareil

    public int sparkling = 2;
    public int astronauts = 15;
    public float asteroids = 1f;

    //creation en cours des objets ?
    public bool createAsteroids = true;
    public bool createAstronauts = true;
    
    //limite
    public int numAsteroid = 6;
    public int numBigAsteroid = 10;
    
    //vitesse
    public Vector2 speed = new Vector2(-5, 0);
    
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
