using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naveScript : MonoBehaviour {
	public float velocidade = 10;
	float width,height;
	public Rigidbody2D rbd;
	// Use this for initialization
	void Start () {
		height = Camera.main.orthographicSize;
		width = height * Camera.main.aspect;
		rbd = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "inimigo") {
			Destroy (col.gameObject);
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		checarLados ();
		andar (x, y);

	}

	void andar(float x, float y){
		rbd.velocity = new Vector2 (x,y) * velocidade;
	}

	private void checarLados(){
		//esquerda
		if (transform.position.x < -height -2.5f) {
			transform.position = new Vector2 (-height - 2.5f, transform.position.y);
		}
		//direita
		if (transform.position.x > height + 2.5f) {
			transform.position = new Vector2 (height + 2.5f, transform.position.y);
		}
		//baixo
		if (transform.position.y < -width/2 -2) {
			transform.position = new Vector2 (transform.position.x, width/2 +2);
		}
		//cima
		if (transform.position.y > width/2 +2) {
			transform.position = new Vector2 (transform.position.x, -width/2 -2);
		}


	}
}
