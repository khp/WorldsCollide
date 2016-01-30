using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

	[SerializeField] public MainGame game;
	[SerializeField] private Text selection;
	[SerializeField] private Text favourText;
	[SerializeField] private Text potentialText;
	[SerializeField] private Text clashChar;
	public int playerNum;
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
		choice = "";
		choiceRes = new Dictionary<string,string> ();
		finished = false;
		clashOn = false;
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
		selection.text = choice;
		UpdateUI ();
		if (clashOn) {
			if (characters.Count > 0) {
				clashChar.text = characters [0];
				ClashInput ();
			} else {
				game.ClashWinner (this);
				finished = true;
			}
			return;
		}
		clashChar.text = "";
		if (choice != "")
			return;
		foreach (string s in choiceRes.Keys) {
			if (Input.GetKey (s)) {
				choice = choiceRes[s];
			}
		}
	}

	void UpdateUI() {
		favourText.text = "Favour: " + favour.ToString ();
		potentialText.text = "Potential: " + potential.ToString ();
	}

	public void ResetPlayer () {
		choice = "";
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
		game.kang.ShowFavour ();
	}

}
