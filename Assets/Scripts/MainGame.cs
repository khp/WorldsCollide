using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainGame : MonoBehaviour {

	private bool clashOn;
	public KanghisKhan kang;
	[SerializeField] private float lastRoundEndTime;
	[SerializeField] private Player player1;
	[SerializeField] private Player player2;
	[SerializeField] private Text timer;

	// Use this for initialization
	void Start () {
		Init ();
	}

	// Update is called once per frame
	void Update () {
		if (!clashOn) {
			float countdown = (3 - Time.time + lastRoundEndTime);
			timer.text = countdown.ToString ("n2");
			if (lastRoundEndTime < Time.time - 3.0f) {
				ResolveChoices ();
				lastRoundEndTime = Time.time;
			}
			player1.StopClash ();
			player2.StopClash ();
		} else {
			timer.text = "CLASH!!!";
			player1.StartClash ();
			player2.StartClash ();
		}
	}


	// This is called when the game begins
	void Init () {
		// set the players initial state
		player1.potential = 0;
		player1.favour = 0;
		player2.potential = 0;
		player2.favour = 0;
		player1.game = this;
		player2.game = this;

		// the game starts without a clash
		clashOn = false;
		lastRoundEndTime = 0.0f;
	}

	void ResolveChoices () {
		if (player1.choice == "" && player2.choice != "") {
			player1.potential = player1.potential == 0 ? 0 : player1.potential - 1;
			player2.potential++;
			kang.Point (player1);
		} else if (player2.choice == "" && player1.choice != "") {
			player1.potential++;
			player2.potential = 0;
			kang.Point (player2);
		} else if (player1.choice == "" && player2.choice == "") {
			player1.potential = 0;
			player2.potential = 0;
			kang.Point (player1);
			kang.Point (player2);
			player2.potential = player2.potential == 0 ? 0 : player2.potential - 1;
		} else if (player1.choice == "" && player2.choice == "") {
			player1.potential = player1.potential == 0 ? 0 : player1.potential - 1;
			player2.potential = player2.potential == 0 ? 0 : player2.potential - 1;
		} else {
			ResolveOfferings ();
		}
		EndRound ();
	}

	void ResolveOfferings () {
		if (player1.choice == player2.choice) {
			//kang raises his arms before the clash begins
			kang.RaiseArms ();
			Clash ();
		} else if (player1.choice == "elephant" && player2.choice == "mouse") {
			player2.potential++;
		} else if (player1.choice == "elephant" && player2.choice == "cat") {
			player1.potential++;
		} else if (player1.choice == "cat" && player2.choice == "elephant") {
			player2.potential++;
		} else if (player1.choice == "cat" && player2.choice == "mouse") {
			player1.potential++;
		} else if (player1.choice == "mouse" && player2.choice == "elephant") {
			player1.potential++;
		} else if (player1.choice == "mouse" && player2.choice == "cat") {
			player2.potential++;
		}
	}

	void Clash () {
		timer.text = "here";
		player1.characters = GenerateCharacters (6);
		player2.characters = GenerateCharacters (6);
		clashOn = true;
		ResolveBattle ();
	}

	List<string> GenerateCharacters (int resultLength) {
	  	List<string> charList = new List<string>()
	    	{
	    	    "a",
	    	    "b",
	    	    "c",
	    	    "d",
	    	    "e",
	    	    "f",
	    	    "g",
	    	    "h",
	    	    "i",
	    	    "j",
	    	    "k",
	    	    "l",
	    	    "m",
	    	    "n",
	    	    "o",
	    	    "p",
	    	    "q",
	    	    "r",
	    	    "s",
	    	    "t",
	    	    "u",
	    	    "v",
	    	    "w",
	    	    "x",
	    	    "y",
	    	    "z"
	        };

	    var charListLength = charList.Count;

		// UnityEngine.Random rnd = new UnityEngine.Random();
	    List<string> charactersGenerated = new List<string>();

	    int charSelected;
	    for (int i = 0; i < resultLength; i++) {
			charSelected = (int) UnityEngine.Random.Range(0, charListLength - 1);
	        charactersGenerated.Add(charList[charSelected]);
	        charList.RemoveAt(charSelected);
	        charListLength = charList.Count;
	    }
	    return charactersGenerated;
	}

	void ResolveBattle () {

	}

	void EndRound () {
		player1.ResetPlayer ();
		player2.ResetPlayer ();
		UpdateFavourBar ();
	}

	void UpdateFavourBar () {

	}

	public void ClashWinner (Player player) {
		player.favour = player.potential + player.favour;
		player1.potential = 0;
		player2.potential = 0;
		clashOn = false;
	}
}
