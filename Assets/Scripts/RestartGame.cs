using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {
	[SerializeField] public MainGame game;
    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (game.gameOver == true) {
        	rend.enabled = true;
		}
	}

	void OnMouseDown () {
    	rend.enabled = false;
		game.gamePaused = false;
		game.intermission = true;
		game.gameOver = false;

		game.RestartGame();
	}

}
