using UnityEngine;

public class Computer : Interactable
{
	[SerializeField] private GamePercentage gamePercentage;
	[SerializeField] private DeveloperStates developerStates;

	public override void Use()
	{
		developerStates.GhostOnPc = true;

		ObjectAnimator.SetBool("GhostProgramming", true);

		gamePercentage.IncreaseGamePercentage(0.1f);

	}

	private void Update()
	{
		ObjectAnimator.SetBool("DeveloperProgramming", developerStates.Programming);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Ghost"))
		{
			ObjectAnimator.SetBool("GhostProgramming", false);
			developerStates.GhostOnPc = false;
		}
	}
}
