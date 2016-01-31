using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusBar : MonoBehaviour {

	[SerializeField] private Image gauge;

	public void UpdateValue (int value) {
		gauge.GetComponent<RectTransform>().localScale = new Vector2((float) value / 20f, 1f);
	}
}
