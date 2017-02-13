using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject g = GameObject.FindWithTag("GameController");
        if (g)
        {
            gameController = g.GetComponent<GameController>();
        } else
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            Instantiate(explosion, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.AddScore(scoreValue);
        }
    }
}
