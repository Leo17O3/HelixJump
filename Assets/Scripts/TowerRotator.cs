using UnityEngine;

public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float _rotationX = touch.deltaPosition.x * Time.deltaTime;
                transform.Rotate(Vector3.up, _rotationX * _rotateSpeed * Time.deltaTime);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                transform.Rotate(Vector3.up, _rotateSpeed);
            }
        }
    }
}
