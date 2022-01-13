using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameState : MonoBehaviour
{
	public static gameState Instance;
	private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
	    
        if(Instance == null){
			Instance = this;
			//DontDestroyOnLoad(Instance.gameObject);
		}else if (this != Instance){
			//Debug.Log("Detruit");
			Destroy(this.gameObject);
		}
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindWithTag("scoreLabel").GetComponent<Text>().text = ""+score;
    }
	public void addScorePlayer(int toAdd) {
		score+=toAdd;
	}
	
	public int getScorePlayer(int toAdd) {
		return score;
	}

	public void resteScore()
	{
		score = 0;
	}

	public void autodestruction()
	{
		Destroy(gameObject.GetComponent<asteroidCreation>());
		GameObject[] tab = GameObject.FindGameObjectsWithTag("asteroid");
		foreach (var asteroid in tab)
		{
			Destroy(asteroid);
		}
	}
}
