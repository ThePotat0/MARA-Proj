using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _runesDict;
    private void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            _runesDict.SetActive(!_runesDict.activeSelf);
        }

    }
}
