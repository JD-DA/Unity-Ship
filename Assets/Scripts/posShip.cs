using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posShip : MonoBehaviour
{
	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;
	
	private Vector3 siz;

    // Start is called before the first frame update
    void Start()
    {
		// calcul des angles avec conversion du monde de la camera au monde du pixel pour 
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,0,0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,1,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,1,0));
        
    }

    // Update is called once per frame
    void Update()
    {
		/*
		calcul de la taille du sprite auquel ce script est attaché
		taile normal = gameobject.getComponent<spriteRender>().bounds.sbyte
		on predn en compte les eventuelles transformations demandes lors des integrations 
		siz vaut alors la taille normale * par les deformations (notamment le zoom)
		*/
        siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		// posiionnement du vaisseau contre le bord gauche de l'écran
		
		if(transform.position.y< leftBottomCameraBorder.y + (siz.y/2))
			gameObject.transform.position=new Vector3 (transform.position.x,leftBottomCameraBorder.y+(siz.y /2),transform.position.z);
		
		if(transform.position.y> leftTopCameraBorder.y - (siz.y/2))
			gameObject.transform.position=new Vector3 (transform.position.x,leftTopCameraBorder.y-(siz.y /2),transform.position.z);
		if(transform.position.x< leftBottomCameraBorder.x + (siz.x/2))
			gameObject.transform.position=new Vector3 (leftBottomCameraBorder.x+(siz.x /2),transform.position.y,transform.position.z);
		
		if(transform.position.x> rightTopCameraBorder.x - (siz.x/2))
			gameObject.transform.position=new Vector3 (rightBottomCameraBorder.x-(siz.x /2),transform.position.y,transform.position.z);
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name=="asteroid"){
			Debug.Log(collider.name);
		}
	}
}
