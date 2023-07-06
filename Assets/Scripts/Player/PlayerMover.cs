using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    const string Horizontal = "Horizontal";
    const string State = "State";
    const string Jumps = "Jump";

    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Player _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _jumpHeight;

    private bool _isGrounded;
    private bool _isMoving = false;
    private bool _isLadder = false;
    private int _maxMovingValue = 2;
    private int _minMovingValue = 1;
    private float _rayLength = 0.2f;
    private Vector2 _direction;
    private float _ledderSpeed = 0.8f;

    public bool IsGrounded => _isGrounded;
    public bool IsMoving => _isMoving;
    public bool IsLadder => _isLadder;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckGround();
    }

    public void LadderMove(RigidbodyType2D Toggle, bool ledderStatus)
    {
        _direction.y = Input.GetAxis("Vertical");
        _animator.SetBool("LadderMove", ledderStatus);
        transform.Translate(Vector3.up * _direction.y * _speed * _ledderSpeed * Time.deltaTime);
        _rigidbody2D.bodyType = Toggle;

        if (ledderStatus)
        {
            _isLadder = true;
            _player.ToggleActiveSpriteWeapon(false);
        }
        else
        {
            _isLadder = false;
            _player.ToggleActiveSpriteWeapon(true);
        }
    }

    public void AnimationJump()
    {
        _animator.SetTrigger(Jumps);
        JumpSetting();
    }

    public void AnimationMove(float inputIndex)
    {
        Move(inputIndex);

        _isMoving = true;
        if (_direction.x != 0)
        {
            Flip();
            _animator.SetInteger(State, _maxMovingValue);
        }
        else
        {
            _animator.SetInteger(State, _minMovingValue);
        }
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _rayLength);
        _isGrounded = colliders.Length > 1;
    }

    private void JumpSetting()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
    }

    private  void Flip()
    {
        if (_direction.x > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }

    public void FlipFromWeapon(bool toogle)
    {
        _spriteRenderer.flipX = toogle;
    }

    private void Move(float inputIndex)
    {
        _direction.x = inputIndex;
        _rigidbody2D.velocity = new Vector2(_direction.x * _speed, _rigidbody2D.velocity.y);
    }
}
