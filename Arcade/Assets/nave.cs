using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nave : MonoBehaviour {
	public float velocidade = 10;
	public Rigidbody2D rbd;
	float width,height;
	public Transform projetil;
	public GameController controller;
	public AudioSource audio;

	public const int maxHealth = 5;
	private int currentHealth = maxHealth;

	private float myTime = 0.0F;
	private float nextFire = 0.5F;
	public float fireDelta = 0.5f;


	void Start () {
		height = Camera.main.orthographicSize;
		width = height * Camera.main.aspect;
		rbd = GetComponent<Rigidbody2D>();

		controller = GameObject.Find ("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag != "Projetil") {
			controller.doDamage();
		}
	}

	public string getCurrentHealth(){
		return currentHealth.ToString();
	}
		
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		rbd.velocity = new Vector2 (x,y) * velocidade;

		checarLados ();

		myTime = myTime + Time.deltaTime;

		if (Input.GetButton ("Fire1") && myTime > nextFire) {
			audio.Play ();
			nextFire = myTime + fireDelta;
			Instantiate (projetil, new Vector2 (transform.position.x, transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y/2 +0.75f ),Quaternion.identity);
			nextFire = nextFire - myTime;
			myTime = 0f;
		}
	}

	private void setPosition(float x, float y){
		transform.position = new Vector2 (x, y);
	}

	private void checarLados(){
		if (transform.position.y > 0) {
			setPosition (transform.position.x, 0);
		}
		if (transform.position.y < -height +1) {
			setPosition (transform.position.x, -height+1);
		}

		if(transform.position.x > width){
			setPosition (-width, transform.position.y);
		}
		if(transform.position.x < -width){
			setPosition (width, transform.position.y);
		}
	}


		

	public void takeDamage()
	{
		currentHealth -= 1;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Destroy (this.gameObject);
			SceneManager.LoadScene (2);
		}
	}
}