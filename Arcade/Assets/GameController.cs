using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text vida;
	public GameObject naveObject;
	private float height;
	private float width;
	private nave nave;

	public AudioSource explosao;
	// Use this for initialization
	void Start () {
		height = Camera.main.orthographicSize;
		width = height * Camera.main.aspect;

		nave = naveObject.gameObject.GetComponent<nave>();
		atualizarVida ();
	}

	public void doDamage(){
		nave.takeDamage();
		atualizarVida ();
	}
	public void destruirNaveInimiga(){
		explosao.Play ();
	}

	private void atualizarVida(){
		vida.text = "Vidas: " + nave.getCurrentHealth();
	}

	public float getHeight(){
		return height;
	}
	public float getWidth(){
		return width;
	}
}
