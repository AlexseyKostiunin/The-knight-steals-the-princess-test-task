using UnityEngine;

public class SurfaceLayer : MonoBehaviour
{  
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private float _checkingRadius;

    [HideInInspector] public bool IsGrounded;

    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(_feetPosition.position
                , _checkingRadius, _whatIsGround);
    }
}
