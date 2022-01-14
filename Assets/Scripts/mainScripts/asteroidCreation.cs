using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidCreation : MonoBehaviour
{
	private Vector3 rightTopCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private Vector3 siz;
	public int luck;

	public bool creating = true;
    // Start is called before the first frame update
    void Start()
    {
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,1,0));
		
    }

    // Update is called once per frame
    void Update()
    {
	    if(creating)
	    {
		    var avgFrameRate = (int) (Time.frameCount / Time.time);
		    Debug.Log(avgFrameRate);
		    var respaws = GameObject.FindGameObjectsWithTag("bigAsteroid");

		    if (respaws.Length < 10)
		    {
			    if (Random.Range(1, avgFrameRate) == 2 )
			    {
				    var mov = new Vector3(rightTopCameraBorder.x + (rightTopCameraBorder.x / 2),
					    Random.Range(leftBottomCameraBorder.y, rightTopCameraBorder.y), 0);

				    string name = "asteroid";
				    name += Random.Range(1, 4).ToString();
				    //Debug.Log(name);
				    GameObject pgo =
					    GameObject.Instantiate(Resources.Load(name), mov, Quaternion.identity) as GameObject;
			    }
		    }
		    
		    respaws = GameObject.FindGameObjectsWithTag("asteroid");

		    if (respaws.Length < 6)
		    {
			    if (Random.Range(1, avgFrameRate) == 2 )
			    {
				    var mov = new Vector3(rightTopCameraBorder.x + (rightTopCameraBorder.x / 2),
					    Random.Range(leftBottomCameraBorder.y, rightTopCameraBorder.y), 0);

				    string name = "asteroid";
				    name += Random.Range(5, 13).ToString();
				    //Debug.Log(name);
				    GameObject pgo =
					    GameObject.Instantiate(Resources.Load(name), mov, Quaternion.identity) as GameObject;
			    }
		    }
	    }
    }
}
