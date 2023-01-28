using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private float enemySpeed = 1f;

	private Rigidbody2D _enemyRb;
	private Vector3 _enemyLocalScale;

	private void Start()
	{
		_enemyRb = GetComponent<Rigidbody2D>();
		_enemyLocalScale = transform.localScale;
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
		_enemyLocalScale.x = -Mathf.Sign(_enemyRb.velocity.x);
		transform.localScale = _enemyLocalScale;
	}
}
