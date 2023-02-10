using UnityEngine;

public class CoinPickups : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		Destroy(gameObject);
	}
}
