using UnityEngine;

public class Interactable : MonoBehaviour
{
	private Animator objectAnimator;
	private DeveloperController developer;
	private bool isMouseOver;
	
	private static readonly int Touched = Animator.StringToHash("Touched");
	private static readonly int MouseOver = Animator.StringToHash("MouseOver");

	protected Animator ObjectAnimator
	{
		get { return objectAnimator; }
		set { objectAnimator = value; }
	}

	private void Awake()
	{
		if (objectAnimator == null)
		{
			ObjectAnimator = GetComponent<Animator>();	
		}
		developer = FindObjectOfType<DeveloperController>();
	}

	public virtual void Use()
	{
		objectAnimator.SetTrigger(Touched);
		developer.Distract(transform, true);
	}

	private void OnMouseOver()
	{
		objectAnimator.SetBool(MouseOver, true);
	}

	private void OnMouseExit()
	{
		objectAnimator.SetBool(MouseOver, false);
	}
}