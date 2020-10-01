using UnityEngine;

public class DeveloperSleep : MonoBehaviour
{
	/// <summary>
	/// How many time's left until developer sleeps
	/// </summary>
	private float sleepTime;
	/// <summary>
	/// Time that player is going to sleep
	/// </summary>
	private float realTimeToSleep;

	[SerializeField] private GameObject sleepParticles;
	[SerializeField] private float timeToSleep;
	[SerializeField] private DeveloperStates developerStates;

	private void Awake()
	{
		realTimeToSleep = timeToSleep;
		sleepTime = Random.Range(10, 20);
	}

	private void Update()
	{
		//Developer sleeping
		if (sleepTime <= 0 && !developerStates.IsDistracted)
		{
			developerStates.ResetData();

			developerStates.Asleep = true;

			sleepParticles.SetActive(timeToSleep > 2);

			timeToSleep -= Time.deltaTime;

			//Developer awake
			if (timeToSleep <= 0)
			{
				sleepTime = Random.Range(6, 14);
				timeToSleep = realTimeToSleep;

				developerStates.Asleep = false;
				developerStates.Programming = true;
			}
		}

		sleepTime -= developerStates.Programming ? Time.deltaTime : 0;
	}
}
