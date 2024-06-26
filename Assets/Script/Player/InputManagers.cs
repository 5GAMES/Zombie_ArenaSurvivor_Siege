using UnityEngine;

public class InputManagers : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    public PlayerMovement.OnFootActions OnFoot;

    private PlayerMotor _motor;
    private PlayerLook _look;
    
    private void Awake()
    {
        _playerMovement = new PlayerMovement();
        OnFoot = _playerMovement.OnFoot;

        _motor = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();

        OnFoot.Jump.performed += ctx => _motor.Jump();

        OnFoot.Crouch.performed += ctx => _motor.Crouch();
        
        //_OnFoot.Sprint.started += ctx => _motor.StartSprint(); // ���������� ������ ������� ������� Shift
        //_OnFoot.Sprint.canceled += ctx => _motor.StopSprint(); // ���������� ���������� ������� Shift

    }
    
    private void FixedUpdate()
    {
        _motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
         OnFoot.Enable();
    }

    private void OnDisable()
    {
        OnFoot.Disable();
    }
}
