using UnityEngine;
using UnityEngine.UI;

public class DeveloperFear : MonoBehaviour
{
	private float fearAmount;

	[SerializeField] private GameEvent playerScared;
	[SerializeField] private Slider fearSlider;

	public Vector2 PreviousObjectMoved { get; set; }

	public void IncreaseFearAmount()
	{
		fearAmount += 20;

		fearSlider.value = fearAmount;

		if (fearAmount >= 100)
		{
			playerScared.Raise();
		}
	}

	public void IsLookingToTheObject(Vector2 objectPosition)
	{
		if (PreviousObjectMoved == objectPosition) return;

		PreviousObjectMoved = objectPosition;

		if (transform.position.x < objectPosition.x)
		{
			if (transform.localScale == Vector3.one)
			{
				IncreaseFearAmount();
			}

			return;
		}

		if (transform.localScale == new Vector3(-1, 1, 1))
		{
			IncreaseFearAmount();
		}
	}
}