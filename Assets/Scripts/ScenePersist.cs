using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{

	private int _currentSceneIndex;
	private void Awake()
	{
		var numberOfScenePersist = FindObjectsOfType<ScenePersist>().Length;
		if (numberOfScenePersist > 1)
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
		_currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}

	private void Update()
	{
		if (SceneManager.GetActiveScene().buildIndex != _currentSceneIndex)
			Destroy(gameObject);
	}
}
