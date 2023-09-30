using UnityEngine;

public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private int _currentTime;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float _rotationX = /*touch.deltaPosition.x * */_rotateSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, _rotationX);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _currentTime = (int)_rotateSpeed;
            }
            else if (_currentTime > 0)
            {
                transform.Rotate(Vector3.up, _rotateSpeed * _currentTime);
                --_currentTime;
            }
        }
    }
}
