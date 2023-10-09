using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _jumpForce;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BasePlatform basePlatform))
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
