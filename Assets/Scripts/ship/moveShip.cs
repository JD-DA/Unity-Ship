using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveShip : MonoBehaviour
{
	// verifier que classe = nom du fichier
	// 1 la vitesse de deplacement
	public Vector2 speed;
	private Vector3 rightTopCameraBorder;
	private Vector3 leftBottomCameraBorder;

	private float maxspeed = 30;
	
	private float smoothTime = 0.01f; 
	Vector3 velocity;
	// 2  Stockage du mouvement (float,float) xy
	private Vector2 movement;
    // Start is called before the first frame update -> on la vire

    private bool translating = false; //use when touch away from the ship, the ship will not teleport to the position but 

    private Vector2 targetPosition3;

    private int mainFinger = -1;
    //translate to it until it reaches it

    private void Start()
    {
	    leftBottomCameraBorder = Camera.main.ViewportToScreenPoint(new Vector3 (0,0,0));
	    rightTopCameraBorder = Camera.main.ViewportToScreenPoint(new Vector3 (1,1,0));
    }

    void Update()
    {
	    var currentPosition = transform.position;
	    if (currentPosition.x == targetPosition3.x && targetPosition3.y == currentPosition.y)
	    {
		    translating = false;
		    Debug.Log("translating ended");
	    }
	    if(translating)
	    {
		    transform.position =
			    Vector3.SmoothDamp(currentPosition, targetPosition3, ref velocity, smoothTime, maxspeed);
		    Debug.Log("translating");
	    }


		    // 3 Recuperer les info du clavier/manette
		    //float inputX = Input.GetAxis("Horizontal"); // renvoie 0 1 -1

		    float inputY = Input.GetAxis("Vertical");

		    // 4 calcul du mouvement
		    movement = new Vector2(
			    0,
			    speed.y * inputY);
		    GetComponent<Rigidbody2D>().velocity = movement;
		   

		    if (inputY == 0)
		    {
			    if (Input.touchCount > 0)
			    {
				    for (int i = 0; i < Input.touchCount; i++)
				    {
					    Touch touch = Input.GetTouch(i);
					    if (touch.phase == TouchPhase.Began && !(IsPointerOverUI(i)) &&
					        touch.position.x < rightTopCameraBorder.x / 3 && mainFinger==-1 )
					    {
						    Rigidbody2D rigid = GetComponent<Rigidbody2D>();
						    Debug.Log($"touch position : ${touch.position}");
						    var targetPosition2 =
							    Camera.main.ScreenToWorldPoint(new Vector3(0, touch.position.y, 0));
						    targetPosition3 = new Vector3(transform.position.x, targetPosition2.y, 0);
						    Debug.Log($"touch position : ${targetPosition3}");
						    Debug.Log($"touch position : ${currentPosition}");
						    Debug.Log($"mainFinger is : ${i}");
						    transform.position = Vector3.SmoothDamp(currentPosition, targetPosition3, ref velocity,
							    smoothTime, maxspeed);
						    translating = true;
						    mainFinger = i;
						    Debug.Log("translating begin");
						    //rigid.MovePosition();
						    break;
					    }
					    else if  (touch.phase == TouchPhase.Moved && i==mainFinger && !translating)
					    {
						    Debug.Log($"mainFinger ${i} mouved");
						    var targetPosition2 =
							    Camera.main.ScreenToWorldPoint(new Vector3(0, touch.position.y, 0));
						    targetPosition3 = new Vector3(transform.position.x, targetPosition2.y, 0);
						    Debug.Log($"touch position : ${targetPosition3}");
						    Debug.Log($"touch position : ${currentPosition}");
						    transform.position = targetPosition3;
						    break;
					    }else if  (touch.phase == TouchPhase.Ended && i==mainFinger)
					    {
						    Debug.Log($"mainFinger ${i} is out");
						    mainFinger = -1;
						    translating = false;
						    break;
					    }
				    }
			    }
		    }
	    

    }
    
    public bool IsPointerOverUI(int fingerId)
    {
	    EventSystem eventSystem = EventSystem.current;
	    return (eventSystem.IsPointerOverGameObject(fingerId)
	            && eventSystem.currentSelectedGameObject != null);
    }
}
