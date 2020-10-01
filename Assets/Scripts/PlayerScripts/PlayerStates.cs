using UnityEngine;

[CreateAssetMenu]
public class PlayerStates : CharacterStates
{
	[SerializeField] private bool isInteracting;
	[SerializeField] private bool isInteractingWithComputer;

	public bool IsInteracting
	{
		get { return isInteracting; }
		set { isInteracting = value; }
	}

	public bool IsInteractingWithComputer
	{
		get { return isInteractingWithComputer; }
		set { isInteractingWithComputer = value; }
	}

	public override void ResetData()
	{
		base.ResetData();

		IsInteracting = false;
		IsInteractingWithComputer = false;
	}
}
