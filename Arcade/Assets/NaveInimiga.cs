using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveInimiga : MonoBehaviour {
	public float heigth,width;

	public Rigidbody2D rbd;
	public GameController controller;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Projetil") {
			Destroy (col.gameObject);
		}
		//controller.destruirNaveInimiga ();
		Destroy (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		heigth = Camera.main.orthographicSize;
		width = heigth * Camera.main.aspect;
		rbd = GetComponent<Rigidbody2D>();

		controller = GameObject.Find ("GameController").GetComponent<GameController>();
	}

	// Update is called once per frame
	void Update () {
		rbd.velocity = new Vector2 (0,-2);
		if (transform.position.y < -heigth -1) {
			Destroy(this.gameObject);
		}
	}
}