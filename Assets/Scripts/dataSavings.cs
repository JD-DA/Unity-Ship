using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataSavings : MonoBehaviour
{
    private int asteroids = 0;

    private int astronauts = 0;

    private int bestScore = 0;

    public static dataSavings Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null){
            Instance = this;
        }else if (this != Instance){
            Destroy(this.gameObject);
        }
        if (PlayerPrefs.HasKey("NumAsteroidsDestroyed"))
            asteroids = PlayerPrefs.GetInt("NumAsteroidsDestroyed");
        if (PlayerPrefs.HasKey("NumAstronautsSaved"))
            astronauts = PlayerPrefs.GetInt("NumAstronautsSaved");
        if (PlayerPrefs.HasKey("BestScore"))
            bestScore = PlayerPrefs.GetInt("BestScore");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getBestScore()
    {
        return bestScore;
    }

    public void saveAsteroid()
    {
        Debug.Log("saveasteroid : "+asteroids);
        ++asteroids;
        PlayerPrefs.SetInt("NumAsteroidsDestroyed", asteroids);
        PlayerPrefs.Save();
    }

    public void saveAstronaut()
    {
        ++astronauts;
        PlayerPrefs.SetInt("NumAstronautsSaved", astronauts);
        PlayerPrefs.Save();
    }

    public bool bestThanBestScore(int score)
    {
        return score > bestScore;
    }

    public void saveScore(int score)
    {
        PlayerPrefs.SetInt("BestScore", score);
        bestScore = score;
        PlayerPrefs.Save();
    }
}
