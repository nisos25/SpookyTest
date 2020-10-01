using UnityEngine;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	public Transform CamTransform;

	// How long the object should shake for.
	public float ShakeDuration;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float ShakeAmount = 0.7f;
	public float DecreaseFactor = 1.0f;

	private Vector3 originalPos;


	private void OnEnable()
	{
		originalPos = CamTransform.localPosition;
	}

	private void Update()
	{
		if (ShakeDuration > 0)
		{
			CamTransform.localPosition = originalPos + Random.insideUnitSphere * ShakeAmount;

			ShakeDuration -= Time.deltaTime * DecreaseFactor;
		}
		else
		{
			ShakeDuration = 0f;
			CamTransform.localPosition = originalPos;
			enabled = false;
		}
	}

	public void IncreaseShakeTime(float shakeAmount)
	{
		ShakeDuration += shakeAmount;
	}
}