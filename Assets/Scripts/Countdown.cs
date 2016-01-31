using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

	public Sprite one;
	public Sprite two;
	public Sprite three;
	public string sprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (sprite == "1") {
			GetComponent<SpriteRenderer> ().sprite = one;
		} else if (sprite == "2") {
			GetComponent<SpriteRenderer> ().sprite = two;
		} else if (sprite == "3") {
			GetComponent<SpriteRenderer> ().sprite = three;
		} else {
			GetComponent<SpriteRenderer> ().sprite = null;
		}
	}
}
