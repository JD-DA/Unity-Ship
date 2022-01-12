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
        //Debug.Log(collider.name);
        Vector3 tmpPos = new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z);
        if (collider.name == "shoot_Orange(Clone)")
        {
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
        
        if(collider.name=="myShip"){
            gameObject.AddComponent<fadeOutFast>();
            GameObject gY = Instantiate(Resources.Load("explosion"), tmpPos, Quaternion.identity) as GameObject;
            invulnerable comp =  collider.GetComponent<invulnerable>();
            if (comp.inactive)
            {
                collider.GetComponent<invulnerable>().startFlash();
                /*if (GameObject.FindGameObjectWithTag("life4"))
                    GameObject.FindGameObjectWithTag("life4").AddComponent<fadeOut>();
                else */
                soundState.Instance.shipTouched();
                if (GameObject.FindGameObjectWithTag("life3"))
                    GameObject.FindGameObjectWithTag("life3").AddComponent<fadeOut>();
                else if (GameObject.FindGameObjectWithTag("life2"))
                    GameObject.FindGameObjectWithTag("life2").AddComponent<fadeOut>();
                else if (GameObject.FindGameObjectWithTag("life1"))
                {
                    GameObject.FindGameObjectWithTag("life1").AddComponent<fadeOut>();
                    gameOver.Instance.GameOver();
                }
            }
        }
    }
    
    
    
}
