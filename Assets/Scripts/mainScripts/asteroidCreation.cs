using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidCreation : MonoBehaviour
{
	private Vector3 rightTopCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private Vector3 siz;
    // Start is called before the first frame update
    void Start()
    {
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,1,0));
		
    }

    // Update is called once per frame
    void Update()
    {
        var respaws = GameObject.FindGameObjectsWithTag("asteroid");
		if(respaws.Length >0){
			siz.x = respaws[0].GetComponent<SpriteRenderer>().bounds.size.x;
			siz.y = respaws[0].GetComponent<SpriteRenderer>().bounds.size.y;
			if(respaws.Length<6){
				if(Random.Range(1,500)==50||respaws.Length<4){
					var mov = new Vector3 (rightTopCameraBorder.x+(siz.x /2),Random.Range(leftBottomCameraBorder.y,rightTopCameraBorder.y),0);
					
					string name = "asteroid";
					name += Random.Range(1, 5).ToString();
					//Debug.Log(name);
					GameObject pgo = GameObject.Instantiate(Resources.Load(name), mov, Quaternion.identity) as GameObject;
				}
			}
		}
    }
}
