using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusBar : MonoBehaviour {

	[SerializeField] private Image gauge;

	public void UpdateValue (int value, int winningFavour) {
		if (value > winningFavour) {
			gauge.GetComponent<RectTransform>().localScale = new Vector2((float) winningFavour / 10f, 1f);		
		} else {
			gauge.GetComponent<RectTransform>().localScale = new Vector2((float) value / 10f, 1f);		
		}
	}
}
