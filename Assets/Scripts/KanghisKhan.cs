using UnityEngine;
using System.Collections;

public class KanghisKhan : MonoBehaviour {

	[SerializeField] private Sprite pointLeft;
	[SerializeField] private Sprite pointRight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Laugh () {
	
	}

	public void RaiseArms () {
	
	}

	public void Point(Player player) {
		if (player.playerNum == 1) {
			GetComponent<SpriteRenderer> ().sprite = pointLeft;
		} else {
			GetComponent<SpriteRenderer> ().sprite = pointRight;
		}
		Laugh ();
	}

	public void ShowFavour () {
	
	}
}
