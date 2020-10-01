using UnityEngine;

public class GamePercentage : MonoBehaviour
{
	[Range(0, 1)]
	[SerializeField] private float percentageMultiplier;

	[SerializeField] private DeveloperStates developerStates;
	[SerializeField] private GameEvent playerWins;


	public float RealPercentage { get; private set; }

	private void Update()
	{
		if (developerStates.Programming)
		{
			IncreaseGamePercentage(Time.deltaTime * percentageMultiplier);
		}
	}

	public void IncreaseGamePercentage(float valueToAdd)
	{
		RealPercentage += valueToAdd;

		if (RealPercentage >= 100)
		{
			RealPercentage = 100;
			playerWins.Raise();
		}
	}
}
