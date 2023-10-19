using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;
using static UnityEditor.Progress;

public class ShopCell : MonoBehaviour
{
    public Action OnBuy;
    [SerializeField] private TextMeshProUGUI _name, _cost;
    [SerializeField] private Image _icon;
    private IShopItem _item;
    private GamaManager _gamaManager;
    private void Start()
    {
      _gamaManager = FindObjectOfType<GamaManager>();
    }
    public void Render(IShopItem item)
    {
        _cost.text = item.Cost.ToString();
        _name.text = item.Name;
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
        _gamaManager.Icones.sprite = _icon.sprite;
        _name.text = "Куплено";
        _item.OnBuy();
        OnBuy?.Invoke();
    }
    
}
