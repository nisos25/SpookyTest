using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	[SerializeField] private PlayerStates playerStates;
	
	private SpriteRenderer ghostSprite;
	private Color ghostSpriteColor;
	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		ghostSprite = GetComponent<SpriteRenderer>();
		ghostSpriteColor = ghostSprite.color;
	}

	private void Update()
	{
		ghostSpriteColor.a = playerStates.IsInteracting ? 0.50f : 1.0f;
		
		ghostSprite.color = ghostSpriteColor;
		
		animator.SetBool("Move", playerStates.IsMoving);
		animator.SetBool("Interact", playerStates.IsInteracting);
		animator.SetBool("Explosion", playerStates.IsInteractingWithComputer);
	}
}
