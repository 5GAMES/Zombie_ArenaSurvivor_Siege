using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class ShopCell : MonoBehaviour
{
    public Action OnBuy;
    [SerializeField] private TextMeshProUGUI _name, _cost;
    [SerializeField] private Image _icon;
    private IShopItem _item;

    public void Render(IShopItem item)
    {
        _cost.text = item.Cost.ToString();
        _name.text = item.Name;
        _icon.sprite = item.Image;
        _item = item;
    }

    public void Buy()
    {
        _item.OnBuy();
        OnBuy?.Invoke();
    }
    
}
