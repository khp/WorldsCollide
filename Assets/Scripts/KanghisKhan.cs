using UnityEngine;
using System.Collections;

public class KanghisKhan : MonoBehaviour {

	[SerializeField] private Sprite pointLeft;
	[SerializeField] private Sprite pointRight;
	[SerializeField] private Sprite rest;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Laugh () {
		//trigger music for laughter
		//animate his head moving up and down
	
	}

	public void RaiseArms () {
		//need sprite of kanghis khan raising arms
	}

	public void Point(Player player) {
		if (player.playerNum == 1) {
			GetComponent<SpriteRenderer> ().sprite = pointLeft;
		} else {
			GetComponent<SpriteRenderer> ().sprite = pointRight;
		}
		Laugh ();
	}

	public void Rest() {
		GetComponent<SpriteRenderer> ().sprite = rest;
	}


	public void ShowFavour () {
	
	}
}
