﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGame : MonoBehaviour {

	private bool clashOn;
	[SerializeField] private float lastRoundEndTime;
	[SerializeField] private GameObject player1FavourBar;
	[SerializeField] private GameObject player2FavourBar;
	[SerializeField] private Player player1;
	[SerializeField] private Player player2;

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

		// the game starts without a clash
		clashOn = false;
	}

	void ResolveChoices () {
		if (player1.choice == null && player2.choice != null) {
			player1.potential = 0;
			player2.potential++;
		} else if (player2.choice == null && player1.choice != null) {
			player1.potential++;
			player2.potential = 0;
		} else if (player1.choice == null && player2.choice == null) {
			player1.potential = 0;
			player2.potential = 0;
		} else {
			ResolveOfferings ();
			EndRound ();
		}
	}

	void ResolveOfferings () {
		if (player1.choice == player2.choice) {
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
		player1.characters = GenerateCharacters ();
		player2.characters = GenerateCharacters ();
		DisplayCharacterBoxes();
		ResolveBattle ();
	}

	IList<string> GenerateCharacters () {
		IList<string> charactersGenerated = new List<string>();
		//some logic to generate random array of characters
		//
		//
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
