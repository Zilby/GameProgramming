using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSize;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = GetComponent<Transform>().position;
    }

    void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        GetComponent<Transform>().position = startPosition + Vector3.forward * newPosition;
	}
}
