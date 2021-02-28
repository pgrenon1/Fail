using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float airControlFactor;
    public ForceMode moveForceMode;
    public float rotationSpeed;
    public Color debugMoveColor;

    [Header("Jump")]
    public float extraDistanceToGround = 0.1f;
    public float jumpInputStickyTime = 0.3f;
    public ForceMode jumpForceMode;
    public float counterJumpForce = 1f;
    public ForceMode counterJumpForceMode;
    public float jumpHeight = 5f;
    public float gravity = -9.81f;
    public bool doubleJump = true;

    [Header("Feedbacks")]
    public GameObject visualsParent;
    public Sound jumpSFX;
    public Sound deathSFX;
    public ParticleSystem deathVFXPrefab;
    public ParticleSystem landingVFX;
    public Animator animator;
    public float runBlendSpeed = 1f;
    public Transform pivot;

    [Header("Pickup")]
    public float pickupDistance;
    public float pickupAngle;
    public Transform pickedUpTargetTransform;
    public float forwardProjectionLength = 1f;

    public GameInputs GameInputs { get { return InputManager.Instance.GameInputs; } }
    //public Pickupable HoveredPickupable { get; private set; }
    //public Pickupable PickedUpPickupable { get; set; }
    public Rigidbody Rigidbody { get; private set; }
    public CinemachineFreeLook CinemachineFreeLook { get; private set; }
    public CinemachineVirtualCamera CinemachineVirtualCamera { get; private set; }

    private CapsuleCollider _capsuleCollider;
    private Vector2 _moveAxis;
    private Vector2 _lookAxis;
    private Vector3 _pickupableVelocity;
    private Vector3 _flatDirection;

    private Vector3 _pickedUpTargetOriginalOffset;
    private Vector3 _groundNormal;
    private Vector3 _targetEulers;
    private bool _hasRequestedJump;
    private float _jumpInputStickyTimer;
    private Vector3 _initialFreeLookPosition;
    private bool _isJumpInputHeld;
    private bool _isjumping;
    private Vector2 _counterJumpForceVector;
    private Vector3 _targetVelocity;
    private float _targetRunDirection;
    private Vector3 _lerpedDirection;
    private bool _isMoving;

    private bool _isGrounded = false;
    private bool IsGrounded
    {
        get { return _isGrounded; }
        set
        {
            if (value != _isGrounded && value)
            {
                if (landingVFX)
                    landingVFX.Play();

                _isjumping = false;
                _hasDoubleJumped = false;
            }

            _isGrounded = value;
        }
    }
    private bool _hasDoubleJumped;

    private void Awake()
    {
        _capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        Rigidbody = GetComponentInChildren<Rigidbody>();
        CinemachineFreeLook = GetComponentInChildren<CinemachineFreeLook>();
        CinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    public void GetInitialFreeLookValues()
    {
        _initialFreeLookPosition = CinemachineFreeLook.transform.position;
    }

    private void Start()
    {
        GameInputs.PlayerActions.Jump.started += ctx => ToggleJumpInput(true);
        GameInputs.PlayerActions.Jump.canceled += ctx => ToggleJumpInput(false);
    }

    private void ToggleJumpInput(bool jumping)
    {
        _isJumpInputHeld = jumping;

        if (_isJumpInputHeld)
        {
            RequestJump();
        }
    }

    private void Update()
    {
        UpdateMovementInput();

        UpdateIsGrounded();

        UpdateAnimationValues();
    }

    private void FixedUpdate()
    {
        FixedUpdateMovement();

        FixedUpdateJump();

        FixedUpdateGravity();
    }

    private void FixedUpdateGravity()
    {
        Rigidbody.AddForce(new Vector3(0, gravity * Rigidbody.mass, 0));

        var velocity = Rigidbody.velocity;
        if (_isjumping)
        {
            if (!_isJumpInputHeld /*&& Vector2.Dot(Rigidbody.velocity, Vector2.up) > 0f*/)
            {
                velocity = velocity + new Vector3(0f, -counterJumpForce * Rigidbody.mass * Time.deltaTime, 0f);
            }
        }

        //velocity = velocity + new Vector3(0, gravity * Rigidbody.mass, 0);

        Rigidbody.velocity = velocity;
    }

    private void FixedUpdateJump()
    {
        if (_hasRequestedJump)
        {
            TryJump();

            _jumpInputStickyTimer += Time.deltaTime;
            if (_jumpInputStickyTimer >= jumpInputStickyTime)
            {
                _hasRequestedJump = false;
            }
        }
    }

    private void TryJump()
    {
        if (IsGrounded)
        {
            Jump();
        }
        else if (doubleJump && !_hasDoubleJumped)
        {
            _hasDoubleJumped = true;

            Jump();
        }
    }

    private void Jump()
    {
        _isjumping = true;

        if (jumpSFX)
            jumpSFX.Play(true);

        var jumpForce = CalculateJumpForce(gravity, jumpHeight);

        Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, 0f, Rigidbody.velocity.z);
        Rigidbody.AddForce(Vector2.up * jumpForce * Rigidbody.mass, jumpForceMode);

        _hasRequestedJump = false;
    }

    private void RequestJump()
    {
        _hasRequestedJump = true;
        _jumpInputStickyTimer = 0;
    }

    private float CalculateJumpForce(float gravityStrength, float jumpHeight)
    {
        //h = v^2/2g
        //2gh = v^2
        //sqrt(2gh) = v
        return Mathf.Sqrt(2 * Mathf.Abs(gravityStrength) * jumpHeight);
    }

    private void UpdateIsGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        IsGrounded = Physics.SphereCast(ray, _capsuleCollider.radius, _capsuleCollider.height / 2f + extraDistanceToGround, LayerMaskManager.Instance.groundLayerMask);
    }

    private void FixedUpdateMovement()
    {
        var scaledMovement = _flatDirection * moveSpeed * Time.fixedDeltaTime;

        if (!IsGrounded)
            scaledMovement = scaledMovement * airControlFactor;

        //var targetPosition = transform.position + scaledMovement;

        Rigidbody.AddForce(scaledMovement, moveForceMode);
    }

    private Vector3 GetFlatDirectionWithCamera(Vector3 direction)
    {
        var movement = Camera.main.transform.TransformDirection(direction);
        var flatMovement = Vector3.ProjectOnPlane(movement, Vector3.up);
        return flatMovement;
    }

    private void UpdateMovementInput()
    {
        _moveAxis = GameInputs.PlayerActions.Move.ReadValue<Vector2>();
        _isMoving = _moveAxis.sqrMagnitude > float.Epsilon;
        _flatDirection = GetFlatDirectionWithCamera(new Vector3(_moveAxis.x, 0, _moveAxis.y));

        DebugExtension.DebugArrow(transform.position, _flatDirection.normalized * 5f, debugMoveColor, 0.2f);
    }

    private void UpdateAnimationValues()
    {
        _lerpedDirection = Vector3.Lerp(_lerpedDirection, _flatDirection.normalized, runBlendSpeed * Time.deltaTime);

        if (_flatDirection.sqrMagnitude > float.Epsilon)
            pivot.rotation = Quaternion.LookRotation(_lerpedDirection);

        DebugExtension.DebugArrow(transform.position, _lerpedDirection * 5f, Color.green, 0.2f);

        animator.SetFloat("MoveX", _lerpedDirection.x);
        animator.SetFloat("MoveZ", _lerpedDirection.z);
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public void ResetCamera()
    {
        CinemachineFreeLook.transform.position = _initialFreeLookPosition;
    }

    public void PlayDeathFeedback()
    {
        visualsParent.SetActive(false);

        deathSFX.Play(true, true);

        if (deathVFXPrefab)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;

        Gizmos.color = Color.green;
        //if (HoveredPickupable == null)
        //    Gizmos.color = Color.red;

        //Gizmos.DrawWireSphere(pickedUpTargetTransform.position, 0.5f);

        Gizmos.color = Color.green;
        if (!IsGrounded)
            Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + Vector3.down * extraDistanceToGround, _capsuleCollider.radius);
    }
}
