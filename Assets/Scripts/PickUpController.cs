using Unity.VisualScripting;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private bool _onClueTrigger = false;
    private Collider _clueObject;
    [SerializeField] private GameObject _clue;
    private void OnTriggerEnter(Collider other)
    {
        _onClueTrigger |= other.GetComponent<Collider>();
        _clueObject = other;
        _clue.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _clueObject = null;
        _onClueTrigger = false;
        _clue.SetActive(false);
    }

    private void Update()
    {
        if (_clueObject.tag == "ClueArea")
        {
            if (Input.GetKey(KeyCode.E) && _onClueTrigger)
            {
                Destroy(_clueObject.gameObject);
                Debug.Log(_clueObject.gameObject.name + " picked up!");
            }
        }
    }
}
