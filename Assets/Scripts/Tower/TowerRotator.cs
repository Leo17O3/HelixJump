using UnityEngine;

public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _extantageForce;
    private int _currentExentageRotateTime;
    private float _rotationX;
    private float _deltaX;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                _deltaX = touch.deltaPosition.x;
                _rotationX = _deltaX * _rotateSpeed * Time.fixedDeltaTime;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _rotationX = 0;
                _currentExentageRotateTime = (int)_rotateSpeed;
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
            transform.Rotate(Vector3.up * -Mathf.Clamp(_deltaX, -1f, 1f) * _rotateSpeed * _extantageForce * _currentExentageRotateTime * Time.fixedDeltaTime);
            --_currentExentageRotateTime;
        }
    }
}
