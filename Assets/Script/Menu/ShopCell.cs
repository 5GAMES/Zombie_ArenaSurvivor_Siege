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
        if(item.GetType() == typeof(ShopGrenade))
        {
            var newItem = (ShopGrenade)item;
            newItem.CheckAllBuyed();
        }
        if (item.IsBuyed) _name.text = "Куплено";
        else _name.text = item.Name;
        
        _cost.text = item.Cost.ToString();
        _icon.sprite = item.Image;
        _item = item;
    }
    public void Buy()
    {
        if (_item.IsBuyed)
        {
            _item.OnBuy();
            return;
        }
        var wallet = PlayerMotor.Singleton.GetComponent<Wallet>();
        if (wallet.Money < _item.Cost) return;
        wallet.SpendMoney(_item.Cost);
        _name.text = "Куплено";
        _item.OnBuy();
        OnBuy?.Invoke();
    }
    
}
