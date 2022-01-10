using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShip : MonoBehaviour
{
	// verifier que classe = nom du fichier
	// 1 la vitesse de deplacement
	public Vector2 speed;
	
	// 2  Stockage du mouvement (float,float) xy
	private Vector2 movement;
    // Start is called before the first frame update -> on la vire
    

    // Update is called once per frame
    void Update()
    {
		
		// 3 Recuperer les info du clavier/manette
		float inputX = Input.GetAxis("Horizontal"); // renvoie 0 1 -1
		float inputY = Input.GetAxis("Vertical");
		
		// 4 calcul du mouvement
		movement = new Vector2(
		speed.x * inputX,
		speed.y * inputY);
		
		GetComponent<Rigidbody2D> ().velocity = movement; // interrogation du rigid body qui est attaché au gameobject, on lui indique le movement en tant que velocity
        
    }
}
