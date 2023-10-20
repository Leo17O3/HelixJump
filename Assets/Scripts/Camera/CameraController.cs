using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Ball _ball;
    private float _minBallPositionY;
    private Vector3 _currentBallPosition => _ball.transform.position;

    [SerializeField] private CameraMove _cameraMove;
    [SerializeField] private CameraRotate _cameraRotate;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        Track();
    }

    private void LateUpdate()
    {    
        if (_currentBallPosition.y < _minBallPositionY)
        {
            Track();
        }
    }

    private void Track()
    {
        _cameraMove.Move(ref _minBallPositionY);
        _cameraRotate.Rotate(_currentBallPosition);
    }
}
