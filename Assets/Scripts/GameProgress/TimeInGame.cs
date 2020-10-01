using UnityEngine;

public class TimeInGame : MonoBehaviour
{
	/// <summary>
	/// Match length given in seconds(1 minute = 60)
	/// </summary>
	[Tooltip("Match length given in seconds(1 minute = 60)")]
	[SerializeField] private float matchLength = 180;

	/// <summary>
	/// In game hours in minutes(1 hour = 60)
	/// </summary>
	[Tooltip("In game hours in minutes(1 hour = 60)")]
	[SerializeField] private int gameHours = 360;

	[SerializeField] private GameEvent playerLoses;


	public float CurrentGameTime { get; private set; }
	public float MinuteLength { get; private set; }


	private void Awake()
	{
		MinuteLength = matchLength / gameHours;
	}

	private void Update()
	{
		CurrentGameTime = CurrentGameTime + Time.deltaTime;

		if (CurrentGameTime >= matchLength)
		{
			playerLoses.Raise();
		}
	}
}
