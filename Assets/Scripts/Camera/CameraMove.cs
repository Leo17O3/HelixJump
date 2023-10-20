using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private Ball _ball;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
    }

    public void Move(ref float minBallPositionY)
    {
        while (_ball == null)
        {
            _ball = FindObjectOfType<Ball>();
        }

        transform.position = _ball.transform.position - _offset;
        minBallPositionY = _ball.transform.position.y;
    }
}
