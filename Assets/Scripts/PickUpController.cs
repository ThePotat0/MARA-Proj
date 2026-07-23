using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpController : MonoBehaviour
{
    private bool _onClueTrigger = false;
    private Collider _clueObject;
    [SerializeField] private GameObject _clue;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _pickUpDistance = 3f;
    [SerializeField] private string _itemName = "Item";

    private void Awake()
    {
        if (_cameraTransform == null && Camera.main != null)
        {
            _cameraTransform = Camera.main.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("ClueArea"))
        {
            return;
        }

        _onClueTrigger = true;
        _clueObject = other;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != _clueObject)
        {
            return;
        }

        _clueObject = null;
        _onClueTrigger = false;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit, _pickUpDistance, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore) && _onClueTrigger && _clue != null)
        {
            _clue.SetActive(true);
        }
        else
        {
            _clue.SetActive(false);
        }
    }

    private void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        if (_clueObject != null && _clueObject.CompareTag("ClueArea"))
        {
            if (Keyboard.current.eKey.wasPressedThisFrame && _onClueTrigger && IsLookingAtItem(out GameObject item))
            {
                Destroy(item);
                Debug.Log(item.name + " picked up!");
            }
        }
    }

    private bool IsLookingAtItem(out GameObject item)
    {
        item = null;

        if (_cameraTransform == null)
        {
            return false;
        }

        if (!Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit, _pickUpDistance, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore))
        {
            return false;
        }

        GameObject hitObject = hit.collider.gameObject;
        if (hitObject.name != _itemName)
        {
            return false;
        }

        item = hitObject;
        return true;
    }
}
