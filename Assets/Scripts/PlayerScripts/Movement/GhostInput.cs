using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GhostController))]
public class GhostInput : MonoBehaviour
{
	private GhostController ghostController;

	[SerializeField] private LayerMask whatCouldBeShot;
	private Camera camera1;

	private void Awake()
	{
		camera1 = Camera.main;
		ghostController = GetComponent<GhostController>();
	}

	private void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}


		if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
		{
			ghostController.ButtonDown = Input.anyKeyDown;
			return;
		}


		Vector2 origin = camera1.ScreenToWorldPoint(Input.mousePosition);

		RaycastHit2D hit = Physics2D.Raycast(origin, origin, 100, whatCouldBeShot);
		
		if (hit)
		{
			ghostController.Clicked(hit);
		}
	}
}
