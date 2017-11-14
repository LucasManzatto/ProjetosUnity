using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	private Vector3 playerCamera;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update () {
		playerCamera = new Vector3 (player.transform.position.x, 0, -10);
		transform.position = playerCamera;
	}
}