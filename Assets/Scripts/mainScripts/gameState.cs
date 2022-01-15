using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class gameState : MonoBehaviour
{
	public static gameState Instance;
	private int score = 0;

	private int astronautSaved;
	bool scoreAstronautsActive = false;

	private GameObject scoreText;

	private GameObject scoreAstronauts;

	public bool doubleShoot;

	private GameObject astronautsSymbole;
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
        astronautsSymbole = GameObject.FindGameObjectWithTag("astronautSymbole");
        scoreAstronauts = GameObject.FindGameObjectWithTag("astronautsScore");
        scoreText = GameObject.FindGameObjectWithTag("scoreLabel");
        scoreAstronauts.SetActive(false);
        astronautsSymbole.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.FindWithTag("scoreLabel").GetComponent<Text>().text = ""+score;
        
    }
	public void addScorePlayer(int toAdd) {
		score+=toAdd;
		scoreText.GetComponent<Text>().text = ""+score;
	}
	
	public int getScorePlayer(int toAdd) {
		return score;
	}

	public void resteScore()
	{
		score = 0;
		astronautSaved = 0;
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
			if (doubleShoot)
			{
				GameObject gm = GameObject.FindGameObjectWithTag("ship");
				GameObject gY = Instantiate(Resources.Load("Ship/myShip"), gm.transform.position, Quaternion.identity) as GameObject;
				Destroy(gm);
				doubleShoot = false;
			}else
			{
				if (GameObject.FindGameObjectWithTag("life3"))
					GameObject.FindGameObjectWithTag("life3").AddComponent<fadeOut>();
				else if (GameObject.FindGameObjectWithTag("life2"))
					GameObject.FindGameObjectWithTag("life2").AddComponent<fadeOut>();
				else if (GameObject.FindGameObjectWithTag("life1"))
				{
					GameObject.FindGameObjectWithTag("life1").AddComponent<fadeOut>();
					gameOver.Instance.GameOver(score, astronautSaved);
				}
			}
			soundState.Instance.shipTouched();
		}
	}

	public void saveAstronaut()
	{
		++astronautSaved;
		if (!scoreAstronautsActive)
		{
			scoreAstronauts.SetActive(true);
			astronautsSymbole.SetActive(true);
			scoreAstronautsActive = true;
		}

		scoreAstronauts.GetComponent<Text>().text = astronautSaved+"";

	}
}
