using UnityEngine;
using System.Collections;

public class LoadMainScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
	}

	// Update is called once per frame
	void OnMouseDown () {
		Application.LoadLevel ("MainScene");
	}
}
