using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    
    GameObject gameOverMenu;
    GameObject pauseButton;
    public static gameOver Instance;
    
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

    public void GameOver()
    {
        Time.timeScale = 0;
        GameObject.Find("battleMusic").GetComponent<AudioSource>().Pause();
        gameOverMenu.SetActive(true);
        pauseButton.SetActive(false);
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
