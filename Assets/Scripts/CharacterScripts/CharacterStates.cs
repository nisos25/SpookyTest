using UnityEngine;

[CreateAssetMenu]
public class CharacterStates : ScriptableObject
{
	[SerializeField] private bool isMoving;

	public bool IsMoving
	{
		get { return isMoving; }
		set { isMoving = value; }
	}

	public virtual void ResetData()
	{
		isMoving = false;
	}
}
