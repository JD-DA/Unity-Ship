using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShoot : MonoBehaviour
{
	
	private Vector3 rightTopCameraBorder;
	private Vector3 leftBottomCameraBorder;
		private Vector3 siz;

    // Start is called before the first frame update -> on la vire
	 void Start()
    {
		// calcul des angles avec conversion du monde de la camera au monde du pixel pour 
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,1,0));

    }

	 public void setShoot(int x)
	 {
		 Debug.Log("inverseShoot");

		 gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(x , 0 );;
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
}
