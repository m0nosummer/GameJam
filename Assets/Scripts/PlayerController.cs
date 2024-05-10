using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool IsGround { get; private set; }

    [SerializeField] private float _moveInput;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
        
    private int _dir;
    private bool _isMoving;
    
    private PlayerInput _playerInput;
    private Rigidbody2D _rb;
    private Animator _anim;
    
    #region CHECK PARAMETERS
    [Header("Checks")] 
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.5f, 0.03f);
    #endregion
    
    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    [SerializeField] private LayerMask _layerTerrain;
    #endregion

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _layerTerrain))
        {
            IsGround = true;
            _anim.SetBool("IsJump", false);
        }
        
        //x축 부호 바꾸기 (좌우반전)
        if (_isMoving)
        {
            transform.localScale = new Vector2(_dir, transform.localScale.y);
        }

        Move(_dir);
        _anim.SetBool("IsRun", _isMoving);
    }
    
    public void OnMove(InputAction.CallbackContext input)
    {
        _moveInput = input.ReadValue<float>();
		
        if (_moveInput > Mathf.Epsilon) _dir = 1;
        else if (_moveInput < -Mathf.Epsilon) _dir = -1;
        else _dir = 0;

        _isMoving = (_dir != 0);
        
    }
    
    public void OnJump(InputAction.CallbackContext input)
    {
        switch (input.phase)
        {
            case InputActionPhase.Started:
                Jump();
                break;
            case InputActionPhase.Canceled:
                IsGround = false;
                _anim.SetBool("IsJump", true);
                break;
        }
    }
    
    private void Jump()
    {
        if (IsGround)
        {
            float force = _jumpForce;
            force -= _rb.velocity.y;
            _rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }

    private void Move(float direction)
    {
        transform.Translate( new Vector2(_moveInput * _moveSpeed * Time.deltaTime, 0f));
    }
    
}
