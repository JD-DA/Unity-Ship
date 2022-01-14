using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    
    GameObject gameOverMenu;
    GameObject pauseButton;
    public static gameOver Instance;
    private int score;
    private int astronauts;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null){
            Instance = this;
            //DontDestroyOnLoad(Instance.gameObject);
        }else if (this != Instance){
            Destroy(this.gameObject);
        }

        gameOverMenu = GameObject.FindGameObjectWithTag("GameOverMenu");
        pauseButton = GameObject.FindGameObjectWithTag("pauseButton");
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(int score,int astronauts)
    {
        var scoreTotal = score + astronauts * 200;
        Time.timeScale = 0;
        GameObject.Find("battleMusic").GetComponent<AudioSource>().Pause();
        gameOverMenu.SetActive(true);
        pauseButton.SetActive(false);
        GameObject.FindGameObjectWithTag("scoreInitial").GetComponent<Text>().text = ""+score;
        GameObject.FindGameObjectWithTag("astronautSavedScore").GetComponent<Text>().text = ""+astronauts;
        GameObject.FindGameObjectWithTag("scoreTotal").GetComponent<Text>().text = scoreTotal+"";
        if (dataSavings.Instance.bestThanBestScore(scoreTotal))
        {
            GameObject.FindGameObjectWithTag("bestScoreLabel").GetComponent<Text>().text = "New Best Score !";
            dataSavings.Instance.saveScore(scoreTotal);
        }
        else
        {
            GameObject.FindGameObjectWithTag("bestScoreLabel").GetComponent<Text>().text = "Best Score :"+dataSavings.Instance.getBestScore();
        }
    }
    public void playGame()
    {
        Time.timeScale = 1;
        gameState.Instance.resteScore();
        SceneManager.LoadScene("InfinitePlay");
        
    }
    public void goToMenu()
    {
        Time.timeScale = 1;
        gameState.Instance.autodestruction();
        Destroy(gameState.Instance);
        Destroy(Camera.main);
        SceneManager.LoadScene("titlescreen");
        Destroy(gameObject);
    }
}
