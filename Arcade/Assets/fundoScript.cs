using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fundoScript : MonoBehaviour {
	public float distancia;
	// Use this for initialization
	void Start () {
		distancia = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (0, -distancia * Time.deltaTime));

		if (transform.position.y < -10) {
			transform.position = new Vector2 (0, 10);
		}
	}
}
