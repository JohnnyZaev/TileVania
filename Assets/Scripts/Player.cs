using UnityEngine;

public class Player : MonoBehaviour
{
	//config
	[SerializeField] private float playerSpeed = 5f;
	[SerializeField] private float playerJumpSpeed = 25f;

	// State
	private bool _isAlive = true;
	
	//cached
	private float _horizontalMovement;
	private Vector2 _playerVelocity;
	private Rigidbody2D _playerRb;
	private Vector3 _playerScale;
	private Animator _playerAnimator;
	private readonly int _isRunning = Animator.StringToHash("IsRunning");

	private void Start()
	{
		_playerScale = transform.localScale;
		_playerRb = GetComponent<Rigidbody2D>();
		_playerAnimator = GetComponent<Animator>();
	}

	private void Update()
	{
		Run();
		Jump();
		FlipSprite();
	}

	private void Run()
	{
		_horizontalMovement = Input.GetAxis("Horizontal");
		_playerVelocity.x = _horizontalMovement * playerSpeed;
		var velocity = _playerRb.velocity;
		_playerVelocity.y = velocity.y;
		velocity = _playerVelocity;
		_playerRb.velocity = velocity;

		bool playerHasHorizontalSpeed = Mathf.Abs(velocity.x) > Mathf.Epsilon;
		_playerAnimator.SetBool(_isRunning, playerHasHorizontalSpeed);
	}

	private void Jump()
	{
		if (Input.GetButtonDown("Jump"))
		{
			_playerVelocity.y = playerJumpSpeed;
			_playerRb.velocity = _playerVelocity;
		}
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
