using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private SurfaceLayer _surface;
    [SerializeField] private float _speedMovement;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private Animator _animationHero;

    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";
    private const string isRunning = "isRunning";
    private const string Jump = "Jump";

    private const byte _stateRest = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animationHero = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MovementHero();
        JumpHero();
    }

    private void MovementHero()
    {
        float horizontalAxis = Input.GetAxis(nameof(Horizontal));

        Vector2 movement = new Vector2(horizontalAxis, 0);
        _rigidbody.AddForce(movement * _speedMovement);

        FaceRotation(horizontalAxis);
        AnimationHorizontalMovement(_animationHero,horizontalAxis);
    }

    private void JumpHero()
    {
        float verticalAxis = Input.GetAxis(nameof(Vertical));
        TryJump(_surface, verticalAxis);        
    }

    private void TryJump(SurfaceLayer surface, float verticalAxis)
    {
        if ((surface.IsGrounded == true) && (verticalAxis > _stateRest))
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            AnimationVerticalJump(_animationHero);            
        }
        else
        {
            surface.IsGrounded = false;
        }
    }

    private void FaceRotation(float horizontalAxis)
    {
        if (horizontalAxis > _stateRest)
            transform.eulerAngles = new Vector2(0, 0);

        else if (horizontalAxis < _stateRest)
            transform.eulerAngles = new Vector2(0, 180);
    }

    private void AnimationHorizontalMovement(Animator animatorMovement, 
        float horizontalAxis)
    {
        if (horizontalAxis == _stateRest)
            animatorMovement.SetBool(nameof(isRunning), false);

        else
            animatorMovement.SetBool(nameof(isRunning), true);
    }

    private void AnimationVerticalJump(Animator animatorJump)
    {
        animatorJump.SetTrigger(nameof(Jump));
    }
}
