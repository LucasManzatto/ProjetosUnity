using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour {
	public Transform naveInimiga;
	public float heigth,width;
	// Use this for initialization


	void Start () {
		width = Camera.main.orthographicSize;
		heigth =  width * Camera.main.aspect;

		InvokeRepeating ("RespawnNave", 1f, 3f);
	}

	void RespawnNave(){
		Instantiate(naveInimiga, new Vector2(width+3,Random.Range(-heigth/2,+heigth/2)), Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {

	}
}

