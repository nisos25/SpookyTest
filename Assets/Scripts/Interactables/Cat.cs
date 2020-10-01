using UnityEngine;

public class Cat : Interactable
{
	[SerializeField] private Rigidbody2D catRigidbody2D;

	public override void Use()
	{
		base.Use();
		ObjectAnimator.SetTrigger("Jump");
		catRigidbody2D.AddForce(new Vector2(0, 400f));
	}

	public void Sitting()
	{
		ObjectAnimator.SetTrigger("Sitting");
	}
}