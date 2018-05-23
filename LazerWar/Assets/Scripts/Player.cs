using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 50f;
    public GameObject laser;
    public Transform firePoint;
    private bool reloaded = true;
    public float reloadDelay = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        if (Input.GetMouseButtonDown(0) && reloaded) {
            reloaded = false;
            Instantiate(laser, firePoint);
            StartCoroutine(Reload());
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && reloaded) {
            reloaded = false;
            Instantiate(laser, firePoint);
            StartCoroutine(Reload());
        }
    }

    void Move() {
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        //dir *= Time.fixedDeltaTime;

        //transform.Translate(dir * speed);
        GetComponent<Rigidbody>().AddForce(dir*speed);
    }

    IEnumerator Reload() {
        float time = 0f;
        while (time < reloadDelay) {
            time += Time.deltaTime;
            yield return null;
        }
        reloaded = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Laser") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
