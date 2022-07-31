using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.5f;
    public float jumpForce = 4f;
    public float longIdleTime = 5f;

    public GameObject initialPosition;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask cliffLayer;
    public TextMeshProUGUI textMeshPro;
    public float groundCheckRadius = 0.05f;
    public float time;
    private float _time;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private float _longIdleTimer;

    private Vector2 _movement;
    private bool _facingRight = true;
    private bool _isGrounded;
    private bool _playerFell;
    private bool _stopTimer = false;

    private bool _isAttacking;
    private Vector3 _absolutePosition;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        time = (time > 0 ? time : 10f);
        _time = time;
        initialPosition = GameObject.Find("PlayerInitialPosition");
        if (initialPosition)
        {
            _absolutePosition = initialPosition.transform.position;
        }
    }

    void Update()
    {
        checkTimeOut();
        if (_isAttacking == false)
        { 
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _movement = new Vector2(horizontalInput, 0f);

            if (horizontalInput < 0f && _facingRight == true)
            {
                Flip();
            }
            else if (horizontalInput > 0f && _facingRight == false)
            {
                Flip();
            }
        }

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (_playerFell)
        {
            Debug.Log("El jugador cayo");
            this.transform.position = _absolutePosition;
            time = _time;
        }

        if (Input.GetButtonDown("Jump") && _isGrounded == true && _isAttacking == false)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        if (_isAttacking == false)
        {
            float horizontalVelocity = _movement.normalized.x * speed;
            _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
        }
    }

    void LateUpdate()
    {
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            _longIdleTimer += Time.deltaTime;
            if (_longIdleTimer >= longIdleTime)
            {
                _animator.SetTrigger("LongIdle");
            }
        }
        else
        {
            _longIdleTimer = 0f;
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void checkTimeOut()
    {
        if (_stopTimer == false)
        {
            time -= Time.deltaTime; // El valor sera negativo dado que hay un tiempo de espera
                                    // para que finalice la animacion
        }
        if (time > 0)
        {
            textMeshPro.text = "Tiempo restante: " + Mathf.Round(time).ToString() + " segundos";
        }
        if (time <= 0)
        {
            _animator.SetBool("time0ut", true);
            _animator.SetTrigger("timeOut");
        }
    }

    private void waitUntilTimeOutAnimationEnds()
    {
        _animator.SetBool("time0ut", false);
        this.transform.position = _absolutePosition;
        time = _time;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cliff"))
        {
            _playerFell = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndPoint"))
        {
            Debug.Log("Mensaje final");
            _stopTimer = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cliff"))
        {
            _playerFell = false;
        }
    }
}
