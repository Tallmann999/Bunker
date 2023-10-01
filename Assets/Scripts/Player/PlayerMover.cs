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
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _footsteps;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _ladderMove;

    private bool _isGrounded;
    private bool _isMoving = false;
    private bool _isLadder = false;
    private int _maxMovingValue = 2;
    private int _minMovingValue = 1;
    private Vector2 _direction;
    private float _rayLength = 0.2f;
    private float _ladderSpeed = 0.8f;

    public bool IsGrounded => _isGrounded;
    public bool IsMoving => _isMoving;
    public bool IsLadder => _isLadder;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource.clip = _footsteps[Random.Range(0,_footsteps.Length)];
    }

    private void Update()
    {
        CheckGround();
    }

    public void LadderMove(RigidbodyType2D Toggle, bool ladderStatus)
    {
        _direction.y = Input.GetAxis("Vertical");
        _animator.SetBool("LadderMove", ladderStatus);
        // ����������� ���� ����� �������� ����� �� ��������
        transform.Translate(Vector3.up * _direction.y * _speed * _ladderSpeed * Time.deltaTime);
        _rigidbody2D.bodyType = Toggle;
       

        if (ladderStatus)
        {
            _isLadder = true;
            _player.TooggleActiveSpriteWeapon(false);
           
        }
        else
        {
            _isLadder = false;
            _player.TooggleActiveSpriteWeapon(true);
            
        }
    }

    public void FootstepSound()
    {
        _audioSource.clip = _footsteps[Random.Range(0, _footsteps.Length)];
        _audioSource.Play();
    }

    public void AnimationJump()
    {
        _animator.SetTrigger(Jumps);
        _audioSource.clip = _jumpSound;
        _audioSource.Play();
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
        //_rigidbody2D.AddForce(new Vector2(_direction.x * _speed*Time.deltaTime, _rigidbody2D.velocity.y));
    }

    private void DieAnimation()
    {

    }
}
