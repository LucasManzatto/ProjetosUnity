using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMegaman : MonoBehaviour {

	public float velocidade;
	public Rigidbody2D rbd;
	public Animator anim;
	// Use this for initialization
	void Start () {
		velocidade = 5;
		rbd = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		rbd.velocity = new Vector2 (x * velocidade,rbd.velocity.y);
		if (x == 0) {
			anim.SetBool ("mover", false);
		} else
			anim.SetBool ("mover", true);
	}
}
