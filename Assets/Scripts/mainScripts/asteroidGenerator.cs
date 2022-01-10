using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asteroidGenerator : MonoBehaviour
{
	public static asteroidGenerator Instance;
	private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null){
			Instance = this;
			DontDestroyOnLoad(Instance.gameObject);
		}else if (this != Instance){
			Destroy(this.gameObject);
		}
    }

    // Update is called once per frame
    void Update()
    {
    }
	/*public void createAsteroid(int toAdd) {
		
	}
	
	public int getScorePlayer(int toAdd) {
		return score;
	}*/
	
}
