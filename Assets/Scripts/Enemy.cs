using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlEnemy : MonoBehaviour
{
    GameController0 gameController; 

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController0>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) 
    { 
        if(collision.gameObject.CompareTag("Bullet")) {

            Debug.Log("Pego una bala");

            gameController.EnemiesKilled();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
