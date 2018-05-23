using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speed = 50;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
	}


}
