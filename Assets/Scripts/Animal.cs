using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour {
	public int playerNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Throw() {
		GetComponent<Rigidbody2D>.AddForce (new Vector2 (5, 5));
	}
}
