using UnityEngine;

public class DeveloperAnimation : MonoBehaviour
{
	[SerializeField] private DeveloperStates developerStates;

	private Animator animator;
	private Vector3 velocity;
	private Vector3 previousPosition;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		previousPosition = transform.position;
	}

	private void Update()
	{
		animator.SetBool("Distract", developerStates.IsDistracted);
		animator.SetBool("PlayerStanding", developerStates.Stand);
		animator.SetBool("Asleep", developerStates.Asleep);

		if (previousPosition == transform.position) return;

		velocity = (transform.position - previousPosition) / Time.deltaTime;
		previousPosition = transform.position;

		float animVelocity =
			velocity.magnitude > 1.5 ? velocity.magnitude - (velocity.magnitude - 1.5f) : velocity.magnitude;

		animator.SetFloat("WalkSpeed", animVelocity);

	}
}
