using UnityEngine;

public class CoinPickups : MonoBehaviour
{
	[SerializeField] private AudioClip coinSound;
	
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (Camera.main != null) AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position);
		Destroy(gameObject);
	}
}
