using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusBar : MonoBehaviour {

	[SerializeField] private Image gauge;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateValue (int value) {
		gauge.GetComponent<RectTransform>.localScale = new Vector2(((200 * value) / 20), 100);
	}
}
