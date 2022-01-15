using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timelineHandler : MonoBehaviour
{
    public static timelineHandler Instance;
    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = true;
    private bool firstTime = true; //on débloque les ennemis
    private bool firstEnemyDestroyed = true;
    
    //indice de rareté, on va multiplier ce nombre par le fps pour générer avec une même cadence approximative selon l'appareil
    [System.NonSerialized]
    public int sparkling = 2;
    [System.NonSerialized]
    public int astronauts = 15;
    [System.NonSerialized]
    public float asteroids = 1f;
    [System.NonSerialized]
    public float enemy = 25;

    [System.NonSerialized] 
    public int enemyShoots = 3;

    //creation en cours des objets ?
    [NonSerialized]
    public bool createAsteroids = true;
    [NonSerialized]
    public bool createAstronauts =true;
    [NonSerialized]
    public bool createEnemy =false;
    
    //limite
    [System.NonSerialized]
    public int numAsteroid = 3;
    [System.NonSerialized]
    public int numBigAsteroid = 7;

    private int enemyTime = 0;
    
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
            numAsteroid = 6;
            numBigAsteroid = 8;
            asteroids = 0.6f;
            astronauts = 25;
        }
        else if (phase2)
        {
            Debug.Log("phase 2 !");
            phase2 = false;
            numAsteroid = 7;
            numBigAsteroid = 10;
            enemyShoots = 4;
        }

        if (time > 5 && time < 35 && (int) time != delta)
        {
            speed += new Vector2(-0.1f, 0);
            delta = (int) time;
        }

        if (time > 25 && firstTime)
        {
            Debug.Log("Enemy time !");
            createEnemy = true;
            firstTime = false;
        }
        
        if (time > 100 && time < 200+enemyTime && (int) time != delta && createEnemy)
        {
            speed += new Vector2(-0.02f, 0);
            delta = (int) time;
        }
        else
        {
            enemyTime++;
        }
    }

    public void ennemyDestroyed()
    {
        if (firstEnemyDestroyed)
        {
            firstEnemyDestroyed = false;
            phase2 = true;
        }

        createEnemy = true;
    }
}
