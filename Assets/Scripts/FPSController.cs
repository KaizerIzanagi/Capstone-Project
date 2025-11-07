using TMPro;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("Movement Speeds")]
    [SerializeField] public float _walkSpeed = 3.0f;
    [SerializeField] public float _sprintMultiplier = 2.0f;
    // I dunno, maybe sprinting? I'm still unsure I'm just laying out the groundwork here.

    [Header("Jump Parameters")]
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private float _gravity = 9.81f;

    [Header("Look Sensitivity")]
    [SerializeField] private float _mouseSensitivity = 2.0f;
    [SerializeField] private float upDownRange = 80.0f;

    [Header("Inputs Customization")]
    [SerializeField] private string _horizontalMoveInput = "Horizontal";
    [SerializeField] private string _verticalMoveInput = "Vertical";
    [SerializeField] private string _mouseXInput = "Mouse X";
    [SerializeField] private string _mouseYInput = "Mouse Y";
    [SerializeField] private KeyCode _sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode _jumptKey = KeyCode.Space;

    [Header("Stamina")]
    [SerializeField] private float _stamina;
    [SerializeField] private GameObject _staminaObj;
    [SerializeField] private TextMeshProUGUI _staminaText;

    private Camera _mainCamera;
    private float _verticalRotation;
    private Vector3 _currentMovement = Vector3.zero;
    private CharacterController _characterController;
    void Awake()
    {
        _stamina = 100f;
        _staminaObj = GameObject.Find("Stamina");
        _staminaText = _staminaObj.GetComponent<TextMeshProUGUI>();
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();

        _staminaText.text = ("Stamina: " + _stamina);
    }

    void HandleMovement()
    {
        float speedMultiplier = Input.GetKey(_sprintKey) ? _sprintMultiplier : 1f;
        if (Input.GetKey(_sprintKey))
        {
            _stamina -= Time.deltaTime * 5;
        }
        else
        {
            _stamina += Time.deltaTime * 4;
        }
        if (_stamina > 100)
        {
            _stamina = 100;
        }

        float verticalSpeed = Input.GetAxis(_verticalMoveInput) * _walkSpeed * speedMultiplier;
        float horizontalSpeed = Input.GetAxis(_horizontalMoveInput) * _walkSpeed * speedMultiplier;

        Vector3 horizontalMovemenet = new Vector3 (horizontalSpeed, 0, verticalSpeed);
        horizontalMovemenet = transform.rotation * horizontalMovemenet;

        HandleGravityAndJumping();

        _currentMovement.x = horizontalMovemenet.x;
        _currentMovement.z = horizontalMovemenet.z;

        _characterController.Move(_currentMovement * Time.deltaTime);
    }

    void HandleGravityAndJumping()
    {
        if (_characterController.isGrounded)
        {
            _currentMovement.y = -0.5f;

            if (Input.GetKeyDown(_jumptKey))
            {
                _currentMovement.y = _jumpForce;
            }
        }
        else
        {
            _currentMovement.y -= _gravity * Time.deltaTime;
        }
    }

    void HandleRotation()
    {
        float mouseXRotation = Input.GetAxis(_mouseXInput) * _mouseSensitivity;
        transform.Rotate(0, mouseXRotation, 0);

        _verticalRotation -= Input.GetAxis(_mouseYInput) * _mouseSensitivity;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -upDownRange, upDownRange);
        _mainCamera.transform.localRotation = Quaternion.Euler(_verticalRotation, 0, 0);
    }
}
