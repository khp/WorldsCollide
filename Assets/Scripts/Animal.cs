using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour {
	public int playerNum;
	public Sprite cat;
	public Sprite mouse;
	public Sprite elephant;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ThrowRight() {
		GetComponent<Transform>().position = new Vector3 (-7.716f, 0.594f, -1f);
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (190, 300));
	}

	public void ThrowLeft() {
		GetComponent<Transform>().position = new Vector3 (7.38f, 0.594f, -1f);
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (-190, 300));
	}
}
