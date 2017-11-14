using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoPokeyScript : MonoBehaviour {

	// Use this for initialization
	public float velocidade;
	void Start () {
		velocidade = 1;
	}

	void OnCollisionEnter2D(Collision2D col){
		velocidade = -velocidade;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 dir = transform.TransformDirection (new Vector2 (velocidade * Time.deltaTime, 0));
		transform.Translate (dir);
	}
}
