using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour {
    // The player for this flame
    public PlayerController p;

    // The ratio the size this flame should increase/decrease
    public float ratio;

    void FixedUpdate()
    {
        var main = GetComponent<ParticleSystem>().main;

        // Rotates the flame in relation to the ship's y rotation
        main.startRotation = p.GetComponent<Rigidbody>().rotation.eulerAngles.y * Mathf.Deg2Rad;

        // Increases/Decreases the flame's size relative to the ship's speed
        main.startSize = 1.3f + (Input.GetAxis("Vertical") * ratio);
    }

}
