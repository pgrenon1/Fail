using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public ForceMode moveForceMode;
    public float rotationSpeed;
    public Color debugMoveColor;

    [Header("Jump")]
    public float extraDistanceToGround = 0.1f;
    public float jumpInputStickyTime = 0.3f;
    public float jumpForce = 10f;
    public ForceMode jumpForceMode;
    public float gravity = -9.81f;

    [Header("Pickup")]
    public float pickupDistance;
    public float pickupAngle;
    public Transform pickedUpTargetTransform;
    public float forwardProjectionLength = 1f;

    public GameInputs GameInputs { get { return InputManager.Instance.GameInputs; } }
    //public Pickupable HoveredPickupable { get; private set; }
    //public Pickupable PickedUpPickupable { get; set; }

    private CapsuleCollider _capsuleCollider;
    private Vector2 _moveAxis;
    private Vector2 _lookAxis;
    private Rigidbody _rigidbody;
    private Vector3 _pickupableVelocity;
    private Vector3 _flatDirection;
    private Vector3 _pickedUpTargetOriginalOffset;
    private Vector3 _groundNormal;
    private Vector3 _targetEulers;
    private bool _hasRequestedJump;
    private float _jumpInputStickyTimer;
    private bool _isGrounded;

    private void Awake()
    {
        _capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        _rigidbody = GetComponentInChildren<Rigidbody>();
        //_pickedUpTargetOriginalOffset = pickedUpTargetTransform.localPosition;
    }

    private void Start()
    {
        GameInputs.PlayerActions.Look.performed += ctx => HandleLook(GameInputs.PlayerActions.Look.ReadValue<Vector2>());
        GameInputs.PlayerActions.Jump.performed += ctx => RequestJump();
    }

    //private void HandlePickup()
    //{
    //    if (PickedUpPickupable != null)
    //    {
    //        Drop();
    //    }
    //    else
    //    {
    //        TryPickup();
    //    }
    //}

    //private void TryPickup()
    //{
    //    if (HoveredPickupable != null)
    //    {
    //        Pickup(HoveredPickupable);
    //    }
    //}

    private void Update()
    {
        UpdateMovementInput();

        //UpdateHoveredPickupable();

        //UpdatePickedUpTarget();

        UpdateIsGrounded();

        //UpdateRotation();

        UpdateGravity();
    }

    private void FixedUpdate()
    {
        FixedUpdateMovement();

        FixedUpdateJumpInput();

        FixedUpdateRotation();
    }

    private void UpdateGravity()
    {
        _rigidbody.AddForce(new Vector3(0, gravity * _rigidbody.mass, 0));
    }

    private void FixedUpdateJumpInput()
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
        if (_isGrounded)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
            _rigidbody.AddForce(Vector3.up * jumpForce, jumpForceMode);

            _hasRequestedJump = false;
        }
    }

    private void RequestJump()
    {
        _hasRequestedJump = true;
        _jumpInputStickyTimer = 0;
    }

    private void UpdateIsGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        _isGrounded = Physics.SphereCast(ray, _capsuleCollider.radius, _capsuleCollider.height / 2f + extraDistanceToGround, LayerMaskManager.Instance.groundLayerMask);
    }

    //private void UpdateHoveredPickupable()
    //{
    //    var clostestPickupableInCone = Util.GetComponentInCone<Pickupable>(transform.position, transform.forward, pickupDistance, pickupAngle, ~0);
    //    if (clostestPickupableInCone != null && PickedUpPickupable == null)
    //    {
    //        HoveredPickupable = clostestPickupableInCone;
    //    }
    //    else
    //    {
    //        HoveredPickupable = null;
    //    }
    //}

    //private void Pickup(Pickupable pickupable)
    //{
    //    PickedUpPickupable = pickupable;
    //    PickedUpPickupable.PickUp();
    //}

    //private void Drop()
    //{
    //    PickedUpPickupable.Drop();
    //    PickedUpPickupable = null;
    //}


    //private void UpdatePickedUpTarget()
    //{
    //    var targetPosition = transform.position + _pickedUpTargetOriginalOffset;

    //    //var groundNormal = Util.GetGroundNormalAtPosition(targetPosition);

    //    pickedUpTargetTransform.position = Vector3.Lerp(pickedUpTargetTransform.position, targetPosition, 0.8f);
    //}

    private void FixedUpdateRotation()
    {
        if (_flatDirection.magnitude > 0f)
        {
            _targetEulers = _flatDirection;
            ApplyCurrentEuler();
        }

        //_targetEulers = Vector3.ProjectOnPlane(_targetEulers, _groundNormal);
    }

    private void ApplyCurrentEuler()
    {
        transform.rotation = Quaternion.LookRotation(_targetEulers);
    }

    private void FixedUpdateMovement()
    {
        var scaledMovement = _flatDirection * moveSpeed * Time.fixedDeltaTime;
        var targetPosition = transform.position + scaledMovement;

        _rigidbody.AddForce(scaledMovement, moveForceMode);
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
        _flatDirection = GetFlatDirectionWithCamera(new Vector3(_moveAxis.x, 0, _moveAxis.y));

        DebugExtension.DebugArrow(transform.position, _flatDirection.normalized * 5f, debugMoveColor, 0.2f);
    }

    private void HandleLook(Vector2 lookAxis)
    {
        _lookAxis = lookAxis;
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
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
        if (!_isGrounded)
            Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + Vector3.down * extraDistanceToGround, _capsuleCollider.radius);
    }
}
