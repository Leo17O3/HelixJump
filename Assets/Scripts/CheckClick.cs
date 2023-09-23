using UnityEngine;

public class CheckClick : MonoBehaviour
{
    private void Start()
    {
        gameObject.AddComponent<BoxCollider>();
    }

    public void SetPosition(Vector3 position) => transform.position = position;

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
