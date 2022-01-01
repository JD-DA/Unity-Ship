using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundState : MonoBehaviour
{
	public static soundState Instance;
	public AudioClip playerShotSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Instance == null){
			Instance = this;
			DontDestroyOnLoad(Instance.gameObject);
		}else if (this != Instance){
			Debug.Log("Detruit");
			Destroy(this.gameObject);
		}
    }
	public void touchButtonSound(){
		MakeSound(playerShotSound);
	}
	
	private void MakeSound(AudioClip originalClip){
		AudioSource.PlayClipAtPoint(originalClip,transform.position);
	}
}
