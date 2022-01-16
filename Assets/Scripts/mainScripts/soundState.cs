using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundState : MonoBehaviour
{
	public static soundState Instance;
	public AudioClip playerShotSound;
	public AudioClip menuSelectSound;

	public AudioClip shipHit;

	private bool makeSounds = true;
    // Start is called before the first frame update
    void Start()
    {
	    if(Instance == null){
		    Instance = this;
	    }else if (this != Instance){
		    //Debug.Log("Detruit");
		    Destroy(this.gameObject);
	    }
	    
	    var sounds = PlayerPrefs.GetInt("playSounds",1);
	    if (sounds == 0)
	    {
		    makeSounds = false;
	    }
	    Debug.Log($"make sounds is ${makeSounds} (${sounds})");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void touchButtonSound(){
		MakeSound(playerShotSound);
	}
	
	public void shipTouched(){
		MakeSound(shipHit);
	}
	
	public void buttonTouchedd(){
		MakeSound(menuSelectSound);
	}
	
	private void MakeSound(AudioClip originalClip){
		Debug.Log($"makeSounds ${makeSounds}");
		if(makeSounds)
		AudioSource.PlayClipAtPoint(originalClip,transform.position);
	}

	public void setMakeSounds(bool val)
	{
		makeSounds = val;
	}
}
