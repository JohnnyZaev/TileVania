using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float playerSpeed = 5f;
	
	private float _horizontalMovement;
	private Vector2 _playerVelocity;
	private Rigidbody2D _playerRb;

	private void Start()
	{
		_playerRb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		Run();
	}

	private void Run()
	{
		_horizontalMovement = Input.GetAxis("Horizontal");
		_playerVelocity.x = _horizontalMovement * playerSpeed;
		_playerVelocity.y = _playerRb.velocity.y;
		_playerRb.velocity = _playerVelocity;
	}
}
