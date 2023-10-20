using UnityEngine;

public class FinishPlatform : BasePlatform
{
    [SerializeField] private WinPanal _winPanal;

    private void Start()
    {
        _winPanal = FindObjectOfType<WinPanal>();
        _winPanal.Disable();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Time.timeScale = 0f;
            _winPanal.Enable();
        }
    }
}
