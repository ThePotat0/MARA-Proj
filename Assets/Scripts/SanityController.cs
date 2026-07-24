using UnityEngine;

public class SanityController : MonoBehaviour
{
    public float CurrentSanity = 100.0f;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Transform _babkaTarget;

    private const float DefaultSanityModifier = 1.0f;
    private const float BabkaVisibleSanityModifier = 2.5f;

    private float _sanityModifier = 1.0f;

    private void Start()
    {
        if (_playerCamera == null)
        {
            _playerCamera = Camera.main;
        }

        if (_babkaTarget == null)
        {
            GameObject babka = GameObject.Find("Babka");
            if (babka != null)
            {
                _babkaTarget = babka.transform;
            }
        }

        ChangeSanity();
    }

    private void Update()
    {
        _sanityModifier = IsBabkaInView() ? BabkaVisibleSanityModifier : DefaultSanityModifier;
    }

    private void ChangeSanity() 
    {
        CurrentSanity -= _sanityModifier;
        Invoke("ChangeSanity", 2);
    }

    private bool IsBabkaInView()
    {
        if (_playerCamera == null || _babkaTarget == null)
        {
            return false;
        }

        Vector3 viewportPoint = _playerCamera.WorldToViewportPoint(_babkaTarget.position);

        return viewportPoint.z > 0.0f
            && viewportPoint.x >= 0.0f
            && viewportPoint.x <= 1.0f
            && viewportPoint.y >= 0.0f
            && viewportPoint.y <= 1.0f;
    }
}
