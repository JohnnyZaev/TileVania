using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		StartCoroutine(LoadNextLevel());
	}

	private IEnumerator LoadNextLevel()
	{
		Time.timeScale = 0.2f;
		yield return new WaitForSecondsRealtime(2f);
		Time.timeScale = 1f;
		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex + 1);
	}
}
