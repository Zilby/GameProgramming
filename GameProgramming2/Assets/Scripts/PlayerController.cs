using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xmin, xmax, zmin, zmax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary bounds;
    public float tilt;
    public GameObject bolt;
    public Transform spawn;
    public float fireRate;
    private float nextFire = 0;

    private void Update()
    {
        if (Input.GetButton("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone = 
            Instantiate(bolt, spawn.position, Quaternion.Euler(0.0f, GetComponent<Rigidbody>().rotation.eulerAngles.y, 0.0f));
            // as GameObject;
            GetComponent<AudioSource>().Play();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, bounds.xmin, bounds.xmax), 0.0f, 
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, bounds.zmin, bounds.zmax));

        // Additionally tilt's the ship's y rotation to lean towards side of turn, as well as rotates ship freely instead of a fixed distance
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, GetComponent<Rigidbody>().velocity.x * tilt, 
            GetComponent<Rigidbody>().rotation.eulerAngles.z + (GetComponent<Rigidbody>().velocity.x * -tilt));
    }
}
