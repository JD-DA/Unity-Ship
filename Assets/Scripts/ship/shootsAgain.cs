using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootsAgain : MonoBehaviour
{
	private Vector3 siz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
		bool sp = Input.GetKeyDown(KeyCode.Space);
		if(sp){
			Vector3 tmpPos = new Vector3(transform.position.x + siz.x,
			transform.position.y,
			transform.position.z);
			GameObject gY = Instantiate (Resources.Load("shoot_Orange"),tmpPos,Quaternion.identity) as GameObject;
			soundState.Instance.touchButtonSound();
		}
    }
}
