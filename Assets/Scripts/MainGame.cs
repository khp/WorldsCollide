using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGame : MonoBehaviour {

	private bool clashOn;
	[SerializeField] private float lastRoundEndTime;
	[SerializeField] private GameObject player1FavourBar;
	[SerializeField] private GameObject player2FavourBar;
	[SerializeField] private Player player1;
	[SerializeField] private Player player2;
	[SerializeField] private KanghisKhan kang;

	// Use this for initialization
	void Start () {
		Init ();
	}

	// Update is called once per frame
	void Update () {
		if (!clashOn) {
			if ((lastRoundEndTime + 2.0) > Time.time) {
				ResolveChoices ();
			}
			player1.StopClash ();
			player2.StopClash ();
		} else {
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
		player2.potential = 0;
		player1.game = this;
		player2.game = this;

		// the game starts without a clash
		clashOn = false;
	}

	void ResolveChoices () {
		if (player1.choice == null && player2.choice != null) {
			player1.potential = 0;
			player2.potential++;
			kang.Point (player1);
		} else if (player2.choice == null && player1.choice != null) {
			player1.potential++;
			player2.potential = 0;
			kang.Point (player2);
		} else if (player1.choice == null && player2.choice == null) {
			player1.potential = 0;
			player2.potential = 0;
			kang.Point (player1);
			kang.Point (player2);
		} else {
			ResolveOfferings ();
			EndRound ();
		}
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
		player1.characters = GenerateCharacters (6);
		player2.characters = GenerateCharacters (6);
		DisplayCharacterBoxes();
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

	    System.Random rnd = new System.Random();
	    List<string> charactersGenerated = new List<string>();

	    int charSelected;
	    for (int i = 0; i < resultLength; i++) {
	        charSelected = rnd.Next(0, charListLength);
	        charactersGenerated.Add(charList[charSelected]);
	        charList.RemoveAt(charSelected);
	        charListLength = charList.Count;
	    }
	    return charactersGenerated;
	}

	void DisplayCharacterBoxes () {
		//some UI stuff
	}

	void ResolveBattle () {

	}

	void EndRound () {
		lastRoundEndTime = Time.time;
		player1.ResetPlayer ();
		player2.ResetPlayer ();
		UpdateFavourBar ();
	}

	void UpdateFavourBar () {

	}

}
