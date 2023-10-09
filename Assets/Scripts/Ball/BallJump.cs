using UnityEngine;

public class BallJump : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _jumpForce;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Ball.Jump += OnJumped;
    }

    private void OnDisable()
    {
        Ball.Jump -= OnJumped;
        _rigidbody = null;
    }

    private void OnJumped()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up *_jumpForce, ForceMode.Impulse);
    }
}
