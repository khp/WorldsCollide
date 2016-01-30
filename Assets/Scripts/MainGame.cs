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
	private IList<char> player1Letters;
	private IList<char> player2Letters;
	private IList<char> player1CharacterInputs;
	private IList<char> player2CharacterInputs;

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
		player1CharacterInputs = new List<char> ();
		player2CharacterInputs = new List<char> ();
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
		player1Letters = GenerateCharacters ();
		player2Letters = GenerateCharacters ();
		SetupKeyTriggers ();
		DisplayCharacterBoxes();
		ResolveBattle ();
	}

	IList<char> GenerateCharacters () {
		IList<char> charactersGenerated = new List<char>();
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
		player1.ResetChoice ();
		player2.ResetChoice ();
		player1Letters.Clear ();
		player2Letters.Clear ();
		player1CharacterInputs.Clear ();
		player2CharacterInputs.Clear ();
		UpdateFavourBar ();
	}

	void UpdateFavourBar () {

	}

}
