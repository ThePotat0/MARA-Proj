using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpController : MonoBehaviour
{
    private bool _onClueTrigger = false;
    private Collider _clueObject;
    [SerializeField] private GameObject _clue;
    private void OnTriggerEnter(Collider other)
    {
        _onClueTrigger = true;
        Debug.Log(_onClueTrigger);
        _clueObject = other;
        _clue.SetActive(true);
        Debug.Log(_clueObject.gameObject.name + " entered clue area!");
    }

    private void OnTriggerExit(Collider other)
    {
        _clueObject = null;
        _onClueTrigger = false;
        Debug.Log(_onClueTrigger);
        _clue.SetActive(false);
        Debug.Log(other.gameObject.name + " exited clue area!");
    }

    private void Update()
    {
        if (_clueObject != null && _clueObject.tag == "ClueArea")
        {
            if (Keyboard.current.eKey.wasPressedThisFrame && _onClueTrigger)
            {
                Destroy(_clueObject.gameObject);
                Debug.Log(_clueObject.gameObject.name + " picked up!");
            }
        }
    }
}
