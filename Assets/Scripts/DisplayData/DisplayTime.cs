using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
	[SerializeField] private Text hourText;
	[SerializeField] private Text minuteText;

	[SerializeField] private TimeInGame timeInGame;

	private void Update()
	{
		//In game hour
		if ((int)(timeInGame.CurrentGameTime / timeInGame.MinuteLength) % 60 == 0)
		{
			hourText.text = ((int)(timeInGame.CurrentGameTime / timeInGame.MinuteLength / 60 % 24)).ToString("00") + ":";
		}

		//In game minute
		if (timeInGame.CurrentGameTime / timeInGame.MinuteLength >= 1)
		{
			minuteText.text = ((int)(timeInGame.CurrentGameTime / timeInGame.MinuteLength % 60)).ToString("00");
		}
	}
}
