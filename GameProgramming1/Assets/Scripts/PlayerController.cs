using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountText ();
		winText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate ()
	{
		float turnHorizontal = Input.GetAxis ("Horizontal") * 2; 
		float turnVertical = Input.GetAxis ("Vertical") * -2; 
		//rb.AddRelativeTorque(turnVertical, turnHorizontal, 0);
		rb.MoveRotation(rb.rotation * Quaternion.Euler(turnVertical, turnHorizontal, 0));
		//rb.MovePosition(transform.position + transform.forward * 0.8F);
		//rb.ResetInertiaTensor(); 
		rb.AddRelativeForce(0, 0, speed);
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag ("Pickup")) {
			++count;
			setCountText ();
			if (count == 8) {
				winText.enabled = true;
			}
		}
	}

	void setCountText () {
		countText.text = "Count: " + count.ToString ();
	}
}
