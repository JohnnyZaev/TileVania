using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private float enemySpeed = 1f;

	private Rigidbody2D _enemyRb;

	private void Start()
	{
		_enemyRb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (IsFacingRight())
		{
			_enemyRb.velocity = Vector2.right * enemySpeed;
		}
		else
		{
			_enemyRb.velocity = Vector2.left * enemySpeed;
		}
	}

	private bool IsFacingRight()
	{
		return transform.localScale.x > 0;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		transform.localScale = new Vector3(-(Mathf.Sign(_enemyRb.velocity.x)), 1f, 1f);
	}
}
