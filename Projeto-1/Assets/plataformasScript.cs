using UnityEngine;
using System.Collections;

public class plataformasScript : MonoBehaviour {

	public float contador=0;
	public float altura;
	public float largura;
	public float velocidade;
	private Vector2 posInicial;

	// Use this for initialization
	void Start () {
		altura = 1;
		largura = 1;
		velocidade = 1;
		posInicial = transform.position;
	}

	// Update is called once per frame
	void Update () {
		contador += velocidade * Time.deltaTime;
		float x = Mathf.Sin(contador) * largura;
		float y = Mathf.Cos(contador) * altura;

		if (contador >= 2 * Mathf.PI) {
			contador = 0 + contador- 2* Mathf.PI;
		}

		transform.position = new Vector2 (x,y) + posInicial;


	}
}

