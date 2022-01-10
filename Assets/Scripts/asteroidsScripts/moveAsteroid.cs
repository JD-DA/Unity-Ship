using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAsteroid : MonoBehaviour
{
    // verifier que classe = nom du fichier
	// 1 la vitesse de deplacement
	public Vector2 speed;
	
	private Vector2 movement;
	
	private Vector3 rightTopCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private Vector3 siz;

	 void Start()
    {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,1,0));
		
		movement = new Vector2(
		speed.x ,
		speed.y );
		
		
		GetComponent<Rigidbody2D> ().velocity = movement;
		GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-100, 100);

    }

    // Update is called once per frame
    void Update()
    {
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		if(transform.position.x< leftBottomCameraBorder.x - (siz.x/2)){
			var mov = new Vector3 (rightTopCameraBorder.x+(siz.x /2),Random.Range(leftBottomCameraBorder.y,rightTopCameraBorder.y),transform.position.z);
					GameObject gY	=	Instantiate(Resources.Load("asteroid1"), mov	,	Quaternion.identity) as	GameObject;

			//gameObject.transform.position=new Vector3 (rightTopCameraBorder.x+(siz.x /2),Random.Range(leftBottomCameraBorder.y,rightTopCameraBorder.y),transform.position.z);
			Destroy(gameObject);
		}
        
    }
	public void OnDestroy()
    {
					
    }
	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name=="myShip"){
			if(GameObject.FindGameObjectWithTag("life4"))
				GameObject.FindGameObjectWithTag("life4").AddComponent<fadeOut>();
			else if(GameObject.FindGameObjectWithTag("life3"))
				GameObject.FindGameObjectWithTag("life3").AddComponent<fadeOut>();
			else if(GameObject.FindGameObjectWithTag("life2"))
				GameObject.FindGameObjectWithTag("life2").AddComponent<fadeOut>();
			else if(GameObject.FindGameObjectWithTag("life1"))
				GameObject.FindGameObjectWithTag("life1").AddComponent<fadeOut>();
		}
	}
	
	
}