using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject laser;
    public Transform firePoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Move(float x, float y) {
        transform.position = new Vector3(x,y,transform.position.z);
    }

    void Shoot() {
        Instantiate(laser, firePoint);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Laser") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
