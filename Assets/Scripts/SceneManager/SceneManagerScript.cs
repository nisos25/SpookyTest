using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
	public void ChangeScene(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
		Time.timeScale = 1;
	}

	public void Exit()
	{
		Application.Quit();
	}
}