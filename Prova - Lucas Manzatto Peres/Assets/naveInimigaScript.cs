using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naveInimigaScript : MonoBehaviour {
	public float width, height;

	public Rigidbody2D rbd;
	// Use this for initialization
	void Start () {
		height = Camera.main.orthographicSize;
		width = height * Camera.main.aspect;
		rbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -height -4f) {
			Destroy (this.gameObject);
		}
		rbd.velocity = new Vector2 (-4, 0);
	}
}
