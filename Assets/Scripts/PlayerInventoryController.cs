using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private GameObject _matchesIconCheck;
    [SerializeField] private GameObject _candleIconCheck;
    [SerializeField] private GameObject _koraIconCheck;
    [SerializeField] private GameObject _ringIconCheck;

    [SerializeField] private GameObject _runesDict;

    private List<GameObject> _items;
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

    public void CollectItem(GameObject item) 
    {
        ItemCheck(item);
    }

    private void ItemCheck(GameObject item) 
    {
        switch (item.name) 
        {
            case "Math": 
                {
                    _matchesIconCheck.SetActive(true);
                    _items.Add(item);
                    break;
                }
            case "Candle": 
                {
                    _candleIconCheck.SetActive(true);
                    break;
                }
            case "Kora": 
                {
                    _koraIconCheck.SetActive(true);
                    break;
                }
            case "Ring": 
                {
                    _ringIconCheck.SetActive(true);
                    break;
                }
                default: 
                {
                    Debug.Log("Invalid item");
                    return;
                }
        }
        _items.Add(item);
    }
}
