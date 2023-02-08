using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
	[SerializeField] private int playerLives = 3;
	
	private void Awake()
	{
		var numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
		if (numberOfGameSessions > 1)
		{
			GameObject o;
			(o = gameObject).SetActive(false);
			Destroy(o);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	public void ProcessPlayerDeath()
	{
		if (playerLives > 1)
		{
			TakeLife();
		}
		else
		{
			ResetGameSession();
		}
	}

	private void TakeLife()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		playerLives--;
	}

	private void ResetGameSession()
	{
		SceneManager.LoadScene(0);
		Destroy(gameObject);
	}
}
