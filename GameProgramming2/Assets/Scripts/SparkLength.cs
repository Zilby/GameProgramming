using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkLength : MonoBehaviour {

    // The player for this spark system
    public PlayerController p;

    // The ratio the length of these sparks should increase/decrease
    public float ratio;

    void FixedUpdate()
    {
        var main = GetComponent<ParticleSystem>().main;

        // Increases/Decreases the spark's length relative to the ship's speed
        if (Input.GetAxis("Vertical") >= 0)
        {
            GetComponent<ParticleSystem>().Play();
            main.startLifetime = 0.2f + (Input.GetAxis("Vertical") * ratio);
        } else
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
