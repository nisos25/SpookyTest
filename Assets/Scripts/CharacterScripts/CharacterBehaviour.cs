using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
	public float Offset { get; set; }
	
	/// <summary>
	/// Moves the player to a desire position
	/// </summary>
	/// <param name="position">Position where player should be moved</param>
	/// <param name="velocity">Movement velocity</param>
	/// <returns>If player is moving</returns>
	public bool Move(Vector2 position, float velocity)
	{
		if (ReachedObjective(position)) return false;

		FaceTarget(position);
		
		transform.position = Vector3.Lerp(transform.position, position, velocity);

		return true;
	}

	/// <summary>
	/// To know if player already reached his objective.
	/// </summary>
	/// <returns></returns>
	public bool ReachedObjective(Vector2 positionToMove)
	{
		float distance = Vector2.Distance(transform.position, positionToMove);

		return distance < Offset;
	}

	/// <summary>
	/// Overload to compare just horizontal position
	/// </summary>
	/// <param name="horizontalPositionToMove">Horizontal position of the objective to compare</param>
	/// <returns>If player reached the objective</returns>
	public bool ReachedObjective(float horizontalPositionToMove)
	{
		float distance = Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(horizontalPositionToMove, 0));

		return distance < Offset;
	}

	/// <summary>
	/// Face target if player is trying to move.
	/// </summary>
	public virtual void FaceTarget(Vector2 positionToMove)
	{
		transform.localScale = transform.position.x > positionToMove.x ? Vector3.one : new Vector3(-1, 1, 1);
	}
}