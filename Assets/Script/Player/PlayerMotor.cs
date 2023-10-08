using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool IsGrounded;
    public float _speed = 5f;
    [SerializeField] float _gravity = -9.8f;
    [SerializeField] float _jumpHeight = 3f;
    [SerializeField] float _crouhTimer = 1f;
    private WeaponSystem _weaponSystem;
    bool _sprinting;
    bool _crouching;
    bool _lerpCrouch;
    private float _previousXPosition;
    private float _previousZPosition;
    private void Start()
    {
        _previousXPosition = transform.position.x;
        _controller = GetComponent<CharacterController>();
        _weaponSystem = FindObjectOfType<WeaponSystem>();
    }
    private void FixedUpdate()
    {
        //Sprint();
        Anim();
    }


    private void Update()
    {
        
        IsGrounded = _controller.isGrounded;
        if(_lerpCrouch)
        {
            _crouhTimer += Time.deltaTime;
            float p = _crouhTimer / 1;
            p *= p;
            if(_crouching)
            {
                _controller.height = Mathf.Lerp(_controller.height, 1, p);
            }
            else
            {
                _controller.height = Mathf.Lerp(_controller.height, 2, p);
            }
            if(p > 1)
            {
                _lerpCrouch = false;
                _crouhTimer = 0f;
            }
        }
        
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);
        _playerVelocity.y += _gravity * Time.deltaTime;
        if (IsGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }
        _controller.Move(_playerVelocity * Time.deltaTime);
       
        

        


    }
    private void Anim()
    {
        if (transform.position.x != _previousXPosition || transform.position.z != _previousZPosition)
        {
           
            

            _previousXPosition = transform.position.x;
            _previousZPosition = transform.position.z;
        }
        else
        {
           // _weaponSystem._anim.SetBool("Run", false);


        }
    }
    public void Jump()
    {
        if (IsGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
        }
    }
    public void Crouch()
    {
        _crouching = !_crouching;
        _crouhTimer = 0f;
        _lerpCrouch = true;

    }
    public void Sprint()
    {
        _sprinting = !_sprinting;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _sprinting = true;
            _weaponSystem._anim.SetBool("Run", true);
            _weaponSystem.DisableShooting();
            _speed = 8;
        }
        else
        {
            _sprinting = false;
            _weaponSystem._anim.SetBool("Run", false);
            _weaponSystem.EnableShooting();
            _speed = 5;
            
        }
    }

}
