using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoTartaguraScript : MonoBehaviour {

	// Use this for initialization
	public float velocidade;
	private GameObject borda;
	public GameObject borda2;

	void Start () {
		borda= GameObject.FindGameObjectsWithTag ("borda")[0];
		velocidade = 1;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject == borda || col.gameObject == borda2) {
			velocidade = -velocidade;
			transform.Rotate (new Vector2 (0, 180));
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 dir = transform.TransformDirection (new Vector2 ( -velocidade * Time.deltaTime, 0));
		transform.Translate (dir);
	}
}
