using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class principalScript : MonoBehaviour {

	public float velocidade;
	public GameObject pe,cabeca,inimigo;
	// Use this for initialization
	private Rigidbody2D rbd;
	public Animator anim,animInimigo,animCaixa;
	private bool chao;
	public float pulo,downTime,totalTime;
	private bool direita;

	void Start () {
		direita = true;
		velocidade = 7;
		pulo = 300;
		rbd = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "moeda") {
			col.gameObject.SetActive (false);
		}
	}	

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "morte") {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			Debug.Log ("Morreu");
		}
		chao = true;
		anim.SetBool ("pular", false);
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");

		movimentacao (x);

		checarPulo ();

		checarToqueCabeca ();

		checarToquePe ();
			


	}

	private void movimentacao(float x){
		andar (x);
		agachar ();
	}

	private void agachar(){
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			anim.SetBool ("agachado", true);
			downTime = Time.time; 

		}
		if(Input.GetKeyUp(KeyCode.DownArrow)){
			totalTime = Time.time - downTime;
			anim.SetBool ("agachado", false);
		}
	}

	private void andar(float x){
		if (x == 0) {
			anim.SetBool ("mover", false);	
		} else
			anim.SetBool ("mover", true);

		if (direita && x < 0 || !direita && x > 0) {
			direita = !direita;
			transform.Rotate (new Vector2 (0, 180));
		}
		if (anim.GetBool ("agachado") == false) {
			Vector2 dir = transform.TransformDirection (new Vector2 (x * velocidade * Time.deltaTime, 0));
			transform.Translate (dir);
		}
	}

	private void checarPulo(){
		if(chao && Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool ("pular", true);
			rbd.AddForce (new Vector2 (0, pulo));
			chao = false;
		}
		
	}

	private void checarToqueCabeca(){
		Collider2D toque;
		toque = Physics2D.OverlapCircle(cabeca.transform.position,0.1f,1<<LayerMask.NameToLayer("caixa"));
		if (toque != null) {
			Debug.Log ("Entrou");
			if (toque.gameObject.layer.Equals(12)) {
				animCaixa.SetBool ("desativar", true);
			}
			else{
				transform.parent = toque.transform;
			}
		}
		else{
			transform.parent=null;
		}
	}

	private void checarToquePe(){
		Collider2D toque;
		toque = Physics2D.OverlapCircle(pe.transform.position,0.1f,1<<LayerMask.NameToLayer("plataforma") | 1<<LayerMask.NameToLayer("inimigo") | 1<<LayerMask.NameToLayer("musical"));

		if (toque != null) {
			if (toque.gameObject.layer.Equals(8)) {
				Debug.Log (toque.gameObject.layer);
				//animInimigo.SetBool ("acertado", true);
				inimigo.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				rbd.AddForce (new Vector2 (0, pulo));
			}
			//musical
			else if (toque.gameObject.layer.Equals(10)) {
				rbd.AddForce (new Vector2 (0, pulo));
			}
			else{
				transform.parent = toque.transform;
			}
		}
		else{
			transform.parent=null;
		}

	}
}
