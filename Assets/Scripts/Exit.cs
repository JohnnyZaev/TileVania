using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex + 1);
	}
}
