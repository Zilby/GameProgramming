using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkOrientation : MonoBehaviour {

	void Update () {
        GetComponent<Transform>().rotation = Quaternion.identity;
	}
}
