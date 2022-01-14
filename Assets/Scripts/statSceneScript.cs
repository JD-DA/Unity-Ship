using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class statSceneScript : MonoBehaviour
{
    void Start()
    {
        var asteroids = PlayerPrefs.GetInt("NumAsteroidsDestroyed",0);
        var astronauts = PlayerPrefs.GetInt("NumAstronautsSaved",0); 
        var score = PlayerPrefs.GetInt("BestScore",0);
        GameObject.FindGameObjectWithTag("scoreTotal").GetComponent<Text>().text = ""+score;
        GameObject.FindGameObjectWithTag("astronautSavedScore").GetComponent<Text>().text = ""+astronauts;
        GameObject.FindGameObjectWithTag("asteroid").GetComponent<Text>().text = asteroids+"";
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("titlescreen");
    }
    
    public void reset()
    {
        PlayerPrefs.SetInt("NumAsteroidsDestroyed", 0);
        PlayerPrefs.SetInt("NumAstronautsSaved", 0);
        PlayerPrefs.SetInt("BestScore", 0);
        PlayerPrefs.Save();
        Start();
    }

}
