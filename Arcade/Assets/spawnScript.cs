using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour {
	public Transform naveInimiga;
	public float heigth,width;
	// Use this for initialization


	void Start () {
		heigth = Camera.main.orthographicSize;
		width = heigth * Camera.main.aspect;
		InvokeRepeating ("RespawnNave", 1f, 3f);
	}

	void RespawnNave(){
		Instantiate(naveInimiga, new Vector2(Random.Range(-width,width),heigth), Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
