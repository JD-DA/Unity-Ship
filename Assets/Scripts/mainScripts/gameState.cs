using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameState : MonoBehaviour
{
	public static gameState Instance;
	private int score = 0;
	public Vector2 speed;
    // Start is called before the first frame update
    void Start()
    {
	    speed = new Vector2(-5, 0);
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

	public void shipColision(GameObject obj)
	{
		invulnerable comp =  obj.GetComponent<invulnerable>();
		if (comp.inactive)
		{
			obj.GetComponent<invulnerable>().startFlash();
                
			soundState.Instance.shipTouched();
			if (GameObject.FindGameObjectWithTag("life3"))
				GameObject.FindGameObjectWithTag("life3").AddComponent<fadeOut>();
			else if (GameObject.FindGameObjectWithTag("life2"))
				GameObject.FindGameObjectWithTag("life2").AddComponent<fadeOut>();
			else if (GameObject.FindGameObjectWithTag("life1"))
			{
				GameObject.FindGameObjectWithTag("life1").AddComponent<fadeOut>();
				gameOver.Instance.GameOver(score,0);
			}
		}
	}
}
