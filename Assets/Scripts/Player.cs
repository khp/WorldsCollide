using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

	[SerializeField] public MainGame game;
	[SerializeField] public Text selection;
	[SerializeField] private Text favourText;
	[SerializeField] private Text potentialText;
	[SerializeField] private Text clashChar;
	[SerializeField] private Animal animal;
	[SerializeField] private StatusBar favourBar;
	[SerializeField] private StatusBar potentialBar;
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
		// selection.text = choice;
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
		if (choice != "" || game.intermission)
			return;
		foreach (string s in choiceRes.Keys) {
			if (Input.GetKey (s)) {
				choice = choiceRes[s];
			}
		}
	}

	void UpdateUI() {
		favourBar.UpdateValue (this.favour);
		potentialBar.UpdateValue (this.potential);
	}

	public void ResetPlayer () {
		choice = "";
	}

	public void StartClash() {
		this.GetComponent<Rigidbody2D> ().isKinematic = false;
		this.Move ();
		clashOn = true;
		finished = false;
	}

	public void StopClash() {
		clashOn = false;
		finished = false;
		this.GetComponent<Rigidbody2D> ().isKinematic = true;
	}
		
	void ClashInput() {
		if (Input.GetKey (characters [0])) {
			characters.RemoveAt (0);
		}
		game.kang.ShowFavour ();
	}

	public void ThrowAnimal(string type) {
		if (type == "cat")
			animal.GetComponent<SpriteRenderer> ().sprite = animal.cat;
		else if (type == "mouse")
			animal.GetComponent<SpriteRenderer> ().sprite = animal.mouse;
		else if (type == "elephant")
			animal.GetComponent<SpriteRenderer> ().sprite = animal.elephant;
		if (playerNum == 1)
			animal.ThrowRight ();
		else
			animal.ThrowLeft ();
	}

	public void Move () {
		if (this.playerNum == 1) {
			if (this.GetComponent<Rigidbody2D> ().rotation <= -20) {
				this.GetComponent<Rigidbody2D> ().AddTorque (10f);			
			} else {
				this.GetComponent<Rigidbody2D> ().AddTorque (-10f);			
			}
		} else {
			if (this.GetComponent<Rigidbody2D> ().rotation >= 20) {
				this.GetComponent<Rigidbody2D> ().AddTorque (-10f);			
			} else {
				this.GetComponent<Rigidbody2D> ().AddTorque (10f);			
			}		
		}
	}

	public void HideAnimal() {
		animal.Hide ();
	}

}
