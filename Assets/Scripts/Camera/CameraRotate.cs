using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public void Rotate(Vector3 target) => transform.LookAt(target);
}
