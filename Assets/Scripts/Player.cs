using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

	[SerializeField] private int playerNum;
	public int favour;
	public int potential;
	public string choice;
	public bool clashOn;
	public bool finished;
	private Dictionary<string,string> choiceRes;
	public List<string> characters;
	// Use this for initialization
	void Start () {
		favour = 0;
		potential = 0;
		choice = null;
		choiceRes = new Dictionary<string,string> ();
		finished = false;
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
		if (clashOn) {
			if (characters.Count > 0) {
				ClashInput ();
			} else {
				finished = true;
			}
			return;
		}

		if (choice != null)
			return;
		foreach (string s in choiceRes.Keys) {
			if (Input.GetKey (s)) {
				choice = choiceRes[s];
			}
		}
	}

	public void ResetPlayer () {
		choice = null;
		characters = null;
	}

	public void StartClash() {
		clashOn = true;
		finished = false;
	}

	public void StopClash() {
		clashOn = false;
		finished = false;
	}
		
	void ClashInput() {
		if (Input.GetKey (characters [0])) {
			characters.RemoveAt (0);
		}
	}

}
