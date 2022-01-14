using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShoot : MonoBehaviour
{
    // verifier que classe = nom du fichier
	// 1 la vitesse de deplacement
	public Vector2 speed;
	
	// 2  Stockage du mouvement (float,float) xy
	private Vector2 movement;
	
	private Vector3 rightTopCameraBorder;
	private Vector3 leftBottomCameraBorder;
		private Vector3 siz;

    // Start is called before the first frame update -> on la vire
	 void Start()
    {
		// calcul des angles avec conversion du monde de la camera au monde du pixel pour 
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,1,0));
		
		movement = new Vector2(
		speed.x ,
		speed.y );
		
		GetComponent<Rigidbody2D> ().velocity = movement;
        
    }

    // Update is called once per frame
    void Update()
    {
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		if(transform.position.x< leftBottomCameraBorder.x - (siz.x/2) || transform.position.x> rightTopCameraBorder.x - (siz.x/2 )){
			Destroy(gameObject);
		}
        
    }
	public void OnDestroy()
    {
					
    }
	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name=="astronaut(Clone)"){
			Destroy(collider.gameObject);
		}
		Destroy(gameObject);
	}
}
