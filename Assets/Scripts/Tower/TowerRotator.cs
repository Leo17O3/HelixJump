using UnityEngine;

public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _extantageForce;
    private int _currentExentageRotateTime;
    private float _rotationX;
    private float _deltaX;

#if UNITY_EDITOR
    private void Start()
    {
        _rotationSpeed *= 100;
    }
#endif

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            float horizontalInput = Input.GetAxisRaw("Mouse X");
            float angle = horizontalInput * _rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.down, angle);
        }
#endif

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                _deltaX = touch.deltaPosition.x;
                _rotationX = _deltaX * _rotationSpeed * Time.fixedDeltaTime;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _rotationX = 0;
                _currentExentageRotateTime = (int)_rotationSpeed;
            }
        }
    }

    private void FixedUpdate()
    {
        if(_rotationX != 0)
        {
            transform.Rotate(Vector3.down * _rotationX);
        }

        if (_currentExentageRotateTime > 0)
        {
            transform.Rotate(Vector3.up * -Mathf.Clamp(_deltaX, -1f, 1f) * _rotationSpeed * _extantageForce * _currentExentageRotateTime * Time.fixedDeltaTime);
            --_currentExentageRotateTime;
        }
    }
}
