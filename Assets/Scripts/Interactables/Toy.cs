using UnityEngine;

public class Toy : Interactable
{
	private void Start()
	{
		ObjectAnimator = GetComponentInParent<Animator>();
	}

	public override void Use()
	{
		base.Use();
		ObjectAnimator.SetTrigger("Click");
	}

	private void OnMouseEnter()
	{
		ObjectAnimator.SetTrigger("Point");
	}
}
