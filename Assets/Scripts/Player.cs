using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float playerSpeed = 5f;
	
	private float _horizontalMovement;
	private Vector2 _playerVelocity;
	private Rigidbody2D _playerRb;
	private Vector3 _playerScale;

	private void Start()
	{
		_playerScale = transform.localScale;
		_playerRb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		Run();
		FlipSprite();
	}

	private void Run()
	{
		_horizontalMovement = Input.GetAxis("Horizontal");
		_playerVelocity.x = _horizontalMovement * playerSpeed;
		_playerVelocity.y = _playerRb.velocity.y;
		_playerRb.velocity = _playerVelocity;
	}

	private void FlipSprite()
	{
		bool playerHasHorizontalSpeed = Mathf.Abs(_playerRb.velocity.x) > Mathf.Epsilon;
		if (playerHasHorizontalSpeed)
		{
			_playerScale.x = Mathf.Sign(_playerVelocity.x);
			transform.localScale = _playerScale;
		}
	}
}
