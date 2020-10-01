using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PauseManager : MonoBehaviour
{
	[SerializeField] private Canvas pauseCanvas;
	[SerializeField] private PostProcessVolume postProcessingFx;
	[SerializeField] private Canvas pauseButtonCanvas;

	[SerializeField] private DeveloperController developerController;
	[SerializeField] private GhostController ghostController;

	public bool IsPaused { get; private set; }

	public void ChangeTimeScale()
	{
		developerController.enabled = !developerController.enabled;
		ghostController.enabled = !ghostController.enabled;
		IsPaused = !IsPaused;
		Time.timeScale = IsPaused ? 0 : 1;
		pauseButtonCanvas.enabled = !pauseButtonCanvas.enabled;
	}

	public void Pause()
	{
		pauseCanvas.enabled = !pauseCanvas.enabled;
		postProcessingFx.enabled = !postProcessingFx.enabled;
		ChangeTimeScale();
	}
}

