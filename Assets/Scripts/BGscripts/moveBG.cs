using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBG : MonoBehaviour
{
	private Vector2 movement;
	public float positionRestartX;
	private Vector3 rightTopCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private Vector3 siz;
    // Start is called before the first frame update
    void Start()
    {
		siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        movement = new Vector2(
		-2 ,
		0 );
		positionRestartX = GameObject.FindGameObjectWithTag("lastBackground").transform.position.x;
		
		GetComponent<Rigidbody2D>().velocity = movement;
		
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,1,0));
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity=movement;
		siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
		
		if(transform.position.x<leftBottomCameraBorder.x -(siz.x/2)){
				transform.position = new Vector3(positionRestartX,transform.position.y,transform.position.z);
    }}
}
