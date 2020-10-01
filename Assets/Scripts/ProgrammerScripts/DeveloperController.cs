using System.Collections;
using Pathfinding;
using UnityEngine;

public class DeveloperController : CharacterBehaviour
{
	private Transform positionToMove;

	private DeveloperFear developerFear;
	private bool scared;

	[SerializeField] private Transform computerChair;
	[SerializeField] private float movementVelocity;
	[SerializeField] private DeveloperStates developerStates;
	[SerializeField] private AIPath aiPath;
	[SerializeField] private AIDestinationSetter destinationSetter;
	private void Awake()
	{
		developerFear = GetComponent<DeveloperFear>();

		developerStates.ResetData();
		developerStates.GhostOnPc = false;
		developerStates.Programming = true;

		Offset = 0.22f;
	}

	private void Update()
	{
		if (developerStates.GhostOnPc)
		{
			if (developerStates.Programming)
			{
				StartCoroutine(WaitForPlayer());
				scared = true;
			}
		}

		if (!developerStates.IsMoving) return;

		if (aiPath.reachedDestination)
		{
			developerStates.IsMoving = false;
			developerStates.Stand = true;
			
			StartCoroutine(ReturnToComputer(true));
		}

		developerStates.Speed = aiPath.velocity.sqrMagnitude;
	}

	/// <summary>
	/// Called when an object wants to distract the player
	/// </summary>
	/// <param name="objectTransform"></param>
	/// <param name="cancelAllMovements"></param>
	public void Distract(Transform objectTransform, bool cancelAllMovements)
	{
		if (developerStates.Asleep) return;

		if (cancelAllMovements)
		{
			StopAllCoroutines();
		}

		positionToMove = objectTransform;

		if (!developerStates.Programming && (Vector2)positionToMove.position != (Vector2)computerChair.position)
		{
			developerFear.IsLookingToTheObject(positionToMove.position);
		}

		developerStates.Programming = false;
		developerStates.IsDistracted = true;

		StartCoroutine(SetState(1.4f));
	}

	/// <summary>
	/// Set player movement to true after a certain time
	/// </summary>
	/// <param name="time"></param>
	/// <returns></returns>
	private IEnumerator SetState(float time)
	{
		yield return new WaitForSeconds(time);
		
		developerStates.Stand = false;
		destinationSetter.target = positionToMove;
		developerStates.IsMoving = true;
		FaceTarget(positionToMove.position);
	}

	private IEnumerator ReturnToComputer(bool firstCall)
	{
		if (firstCall)
		{
			yield return new WaitForSeconds(1f);
			Distract(computerChair, false);

			if (developerStates.GhostOnPc)
			{
				yield return new WaitForSeconds(1.6f);
				developerFear.IsLookingToTheObject(positionToMove.position);
			}
		}

		if (ReachedObjective(computerChair.position))
		{
			developerStates.ResetData();
			developerStates.Programming = true;

			developerFear.PreviousObjectMoved = Vector2.zero;

			transform.localScale = new Vector3(1f, 1f, 1f);

			yield break;
		}
		
		//positionToMove = computerChair;

		yield return null;

		StartCoroutine(ReturnToComputer(false));
	}

	/// <summary>
	/// To control if player is scared
	/// </summary>
	/// <returns></returns>
	private IEnumerator WaitForPlayer()
	{
		if (scared)
		{
			yield break;
		}

		yield return new WaitForSeconds(1);

		if (!developerStates.GhostOnPc)
		{
			yield break;
		}

		developerFear.IncreaseFearAmount();

		scared = false;
	}

	public override void FaceTarget(Vector2 positionToMove)
	{
		transform.localScale = transform.position.x < positionToMove.x ? Vector3.one : new Vector3(-1, 1, 1);
	}
}