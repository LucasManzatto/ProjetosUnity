using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour {
	public float heigth,width;
	public Rigidbody2D rbd;

	void Start () {
		heigth = Camera.main.orthographicSize;
	}
		
	void Update () {
		rbd.velocity = new Vector2 (0,10);
		if (transform.position.y > heigth +1) {
			Destroy(this.gameObject);
		}
	}
}
