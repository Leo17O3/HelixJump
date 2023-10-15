using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _offsetY;
    [SerializeField] private Vector3 _offset;

    private Ball _ball;
    private Beam _beam;

    private int _minBallPositonY;

    private Vector3 _cameraPosition => transform.position;
    private Vector3 _currentBallPosition => _ball.transform.position;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        Quaternion newRotation = Quaternion.LookRotation(_ball.transform.position - transform.position);

        _minBallPositonY = (int)_currentBallPosition.y;
        transform.rotation = newRotation;
        transform.position = _currentBallPosition - _offset;
    }

    private void LateUpdate()
    {
        if ((int)_currentBallPosition.y < _minBallPositonY)
        {
            Track();
        }
    }

    private void Track()
    {
        Quaternion newRotation = Quaternion.LookRotation(_ball.transform.position - transform.position);
        transform.rotation = newRotation;

        transform.position = new Vector3(_cameraPosition.x, _currentBallPosition.y + _offsetY, _cameraPosition.z);
        transform.position = _currentBallPosition -  _offset;
        _minBallPositonY = (int)_currentBallPosition.y;
    }
}
