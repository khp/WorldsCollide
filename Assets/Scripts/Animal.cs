using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour {
	public int playerNum;
	public Sprite cat;
	public Sprite mouse;
	public Sprite elephant;
	public string animalType;

	public AudioSource catAlive;
	public AudioSource catDead;
	public AudioSource mouseAlive;
	public AudioSource mouseDead;
	public AudioSource elephantAlive;
	public AudioSource elephantDead;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SetSprite ();
	}

	public void ThrowRight() {
		GetComponent<Transform>().position = new Vector3 (-7.716f, 0.594f, -1f);
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (400, 300));
	}

	public void ThrowLeft() {
		GetComponent<Transform>().position = new Vector3 (7.38f, 0.594f, -1f);
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (-400, 300));
	}

	public void Hide() {
		Vector2 oldVector = GetComponent<Transform> ().position;
		GetComponent<Transform> ().position = new Vector3 (oldVector.x, oldVector.y, 1);
	}

	public void RegularSound() {
		if (animalType == "cat")
			catAlive.Play ();
		else if (animalType == "mouse")
			mouseAlive.Play ();
		else if (animalType == "elephant")
			elephantAlive.Play ();
	}

	public void DeathSound() {
		if (animalType == "cat")
			catDead.Play ();
		else if (animalType == "mouse")
			mouseDead.Play ();
		else if (animalType == "elephant")
			elephantDead.Play ();
	}

	public void SetSprite () {
		Sprite currentSprite;
		if (animalType == "cat")
			currentSprite = cat;
		else if (animalType == "mouse")
			currentSprite = mouse;
		else if (animalType == "elephant")
			currentSprite = elephant;
		else
			currentSprite = null;
		GetComponent<SpriteRenderer> ().sprite = currentSprite;
	}
}
