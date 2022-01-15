using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timelineHandler : MonoBehaviour
{
    public static timelineHandler Instance;
    private bool phase1 = true;
    private bool phase2 = true;
    private bool phase3 = true;
    
    //indice de rareté, on va multiplier ce nombre par le fps pour générer avec une même cadence approximative selon l'appareil
    [System.NonSerialized]
    public int sparkling = 2;
    [System.NonSerialized]
    public int astronauts = 15;
    [System.NonSerialized]
    public float asteroids = 1f;

    //creation en cours des objets ?
    public bool createAsteroids = true;
    public bool createAstronauts = true;
    
    //limite
    [System.NonSerialized]
    public int numAsteroid = 6;
    [System.NonSerialized]
    public int numBigAsteroid = 7;
    
    //vitesse
    [System.NonSerialized]
    public Vector2 speed = new Vector2(-5, 0);

    private int delta=0;
    
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
        var time = Time.timeSinceLevelLoad;
        if (phase1 && time > 15)
        {
            Debug.Log("phase 1 !");
            phase1 = false;
            numAsteroid = 9;
            numBigAsteroid = 10;
            asteroids = 0.6f;
            astronauts = 25;
        }
        else if (phase2 && time > 45)
        {
            Debug.Log("phase 2 !");
            phase2 = false;
            numAsteroid = 12;
            numBigAsteroid = 14;
        }

        if (time > 5 && time < 45 && (int) time != delta)
        {
            speed += new Vector2(-0.1f, 0);
            delta = (int) time;
        }
        
        if (time > 100 && time < 200 && (int) time != delta)
        {
            speed += new Vector2(-0.02f, 0);
            delta = (int) time;
        }
    }
}
