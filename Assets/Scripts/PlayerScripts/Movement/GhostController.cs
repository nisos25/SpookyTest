using System.Collections;
using UnityEngine;

public class GhostController : CharacterBehaviour
{
	[SerializeField] private PlayerStates playerStates;
	[SerializeField] private float movementVelocity;
	[SerializeField] private GameEvent buttonPressed;

	private Interactable interactable;
	private Vector3 positionToMove;
	private SpriteRenderer spriteRenderer;

	public bool ButtonDown { get; set; }

	private void Awake()
	{
		playerStates.ResetData();   //All data should be restarted before the game starts.

		Offset = 0.3f;
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	private void Update()
	{
		if (playerStates.IsMoving)
		{
			playerStates.IsMoving = Move(positionToMove, movementVelocity);
		}

		if (playerStates.IsInteractingWithComputer && ButtonDown)
		{
			StartCoroutine(InteractionCaller());
			buttonPressed.Raise();
			ButtonDown = false;
		}
	}

	/// <summary>
	/// Called when player hit a new location, realize if player could interact or simply reach the point.
	/// </summary>
	/// <param name="hitLocation">Location where player is trying to move.</param>
	/// <param name="touchedInteractable">Interactable detected by the hit location</param>
	public void Clicked(RaycastHit2D hitLocation)
	{
		positionToMove = hitLocation.point;
		interactable = hitLocation.transform.GetComponent<Interactable>();

		FaceTarget(positionToMove);

		playerStates.IsMoving = true;
		playerStates.IsInteracting = false;

		if (interactable != null)
		{
			playerStates.IsInteractingWithComputer = interactable.GetType() == typeof(Computer) &&
													 playerStates.IsInteractingWithComputer;

			if (!playerStates.IsInteractingWithComputer)
			{
				StartCoroutine(InteractionCaller());
			}
		}
		else
		{
			playerStates.IsInteractingWithComputer = false;
		}

		spriteRenderer.enabled = !playerStates.IsInteractingWithComputer;

	}

	/// <summary>
	/// To start the interaction.
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractionCaller()
	{
		while (interactable != null)
		{
			if (ReachedObjective(positionToMove))
			{
				interactable.Use();

				playerStates.IsInteractingWithComputer = interactable.GetType() == typeof(Computer);
				playerStates.IsInteracting = true;

				yield return new WaitForSeconds(0.6f);

				spriteRenderer.enabled = !playerStates.IsInteractingWithComputer;

				yield break;
			}

			yield return null;
		}
	}
}