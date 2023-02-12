using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
	[SerializeField] private int playerLives = 3;
	[SerializeField] private TMP_Text livesText;
	[SerializeField] private TMP_Text scoreText;

	private int _currentScore;
	
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

	private void Start()
	{
		livesText.text = playerLives.ToString();
		scoreText.text = _currentScore.ToString();
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
		livesText.text = playerLives.ToString();
	}

	private void ResetGameSession()
	{
		SceneManager.LoadScene(0);
		Destroy(gameObject);
	}
}
