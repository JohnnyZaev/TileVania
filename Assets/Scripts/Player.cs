using UnityEngine;

public class Player : MonoBehaviour
{
	//config
	[SerializeField] private float playerSpeed = 5f;
	[SerializeField] private float playerJumpSpeed = 25f;
	[SerializeField] private float climbSpeed = 5f;
	[SerializeField] private Vector2 dyingKick = new Vector2(25f, 25f);

	// State
	private bool _isAlive = true;
	
	//cached
	private float _horizontalMovement;
	private Vector2 _playerVelocity;
	private Rigidbody2D _playerRb;
	private Vector3 _playerScale;
	private Animator _playerAnimator;
	private readonly int _isRunning = Animator.StringToHash("IsRunning");
	private readonly int _isClimbing = Animator.StringToHash("IsClimbing");
	private CapsuleCollider2D _playerBodyCollider2D;
	private BoxCollider2D _playerFeetCollider2D;
	private int _groundLayerMask;
	private int _enemyLayerMask;
	private float _gravityScaleAtStart;
	private static readonly int Dying = Animator.StringToHash("Dying");

	private void Start()
	{
		_playerScale = transform.localScale;
		_playerRb = GetComponent<Rigidbody2D>();
		_playerAnimator = GetComponent<Animator>();
		_playerFeetCollider2D = GetComponent<BoxCollider2D>();
		_playerBodyCollider2D = GetComponent<CapsuleCollider2D>();
		_groundLayerMask = LayerMask.GetMask("Ground");
		_enemyLayerMask = LayerMask.GetMask("Enemy", "Hazard");
		_gravityScaleAtStart = _playerRb.gravityScale;
	}

	private void Update()
	{
		if (!_isAlive)
			return;
		Run();
		Jump();
		FlipSprite();
		ClimbLadder();
		Die();
	}


	private void Die()
	{
		if (_playerBodyCollider2D.IsTouchingLayers(_enemyLayerMask))
		{
			_playerAnimator.SetTrigger(Dying);
			_playerRb.velocity = dyingKick;
			_isAlive = false;
		}
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

	private void ClimbLadder()
	{
		if (!_playerBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
		{
			_playerRb.gravityScale = _gravityScaleAtStart;
			_playerAnimator.SetBool(_isClimbing, false);
			return;
		}

		_playerRb.gravityScale = 0f;
		var verticalMovement = Input.GetAxis("Vertical");
		_playerVelocity.y = verticalMovement * climbSpeed;
		_playerRb.velocity = _playerVelocity;

		var playerHasVerticalSpeed = Mathf.Abs(_playerRb.velocity.y) > Mathf.Epsilon;
		_playerAnimator.SetBool(_isClimbing, playerHasVerticalSpeed);
	}

	private void Jump()
	{
		if (Input.GetButtonDown("Jump") && _playerFeetCollider2D.IsTouchingLayers(_groundLayerMask))
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
