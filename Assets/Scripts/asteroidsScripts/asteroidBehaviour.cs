using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidBehaviour : MonoBehaviour
{
    private int score;
    private int hit;
    public int idDestruct; //utilisé dans le cas ou deux asteroid pop avec colision, on détruit celui avec le plus petit id
    
    // Start is called before the first frame update
    void Start()
    {
        score = 10;
        idDestruct = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore(int sc)
    {
        score = sc;
    }

    public void setHit(int h)
    {
        hit = h;
    }

    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log(collider.name);
        if (collider.name == "shoot_Orange(Clone)")
        {
            Vector3 tmpPos = new Vector3(transform.position.x,
                transform.position.y,
                transform.position.z);
            gameObject.AddComponent<fadeOutFast>();
            GameObject gY = Instantiate(Resources.Load("explosion"), tmpPos, Quaternion.identity) as GameObject;
            gameState.Instance.addScorePlayer(score);
        }

        if (collider.name.Length >= 8)
        {
            Debug.Log(collider.name.Substring(0,8));
            if(collider.name.Substring(0,8)=="asteroid")
            {
                if (collider.gameObject.GetComponent<asteroidBehaviour>().idDestruct > idDestruct)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    
    
    
}
