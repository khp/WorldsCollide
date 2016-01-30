using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

	[SerializeField] private int playerNum;
	public int favour;
	public int potential;
	public string choice;
	public bool gameOn;
	private Dictionary<string,string> choiceRes;
	// Use this for initialization
	void Start () {
		favour = 0;
		potential = 0;
		choice = null;
		choiceRes = new Dictionary<string,string> ();
		if (playerNum == 1) {
			choiceRes.Add ("1", "mouse");
			choiceRes.Add ("2", "cat");
			choiceRes.Add ("3", "elephant");
		} else {
			choiceRes.Add ("8", "mouse");
			choiceRes.Add ("9", "cat");
			choiceRes.Add ("0", "elephant");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (choice != null)
			return;
		foreach (string s in choiceRes.Keys) {
			if (Input.GetKey (s)) {
				choice = choiceRes[s];
			}
		}
	}

	public void ResetChoice () {
		choice = null;
	}
}
