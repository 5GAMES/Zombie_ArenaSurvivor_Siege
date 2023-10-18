using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Links : ")]
    
    [SerializeField] private Transform _container;
    [SerializeField] private ShopCell _cell;
    [SerializeField] private List<ShopItem> _items;
    private int _curretnPage = 0;
    private int _drawOnOneScreen = 9;
    private void OnEnable()
    {
        Render();
    }

    private void Render()
    {
        foreach(Transform child in _container) Destroy(child.gameObject);
        var itemsCount = _curretnPage + _drawOnOneScreen;
        for(int i = _curretnPage; i < itemsCount; i++)
        {
            if (i > _items.Count - 1) return;
            var cell = Instantiate(_cell, _container);
            cell.Render(_items[i]);
        }
    }

    public void Forward()
    {
        if(_curretnPage + 9 > _items.Count + 9) _curretnPage = -9;
        _curretnPage += 9;
        Render();
    }

    public void Back()
    {
        if(_curretnPage - 9 < 0) _curretnPage = _items.Count + 9;
        
        _curretnPage -= 9;
        Render();
    }
}
