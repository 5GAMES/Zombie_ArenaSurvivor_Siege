using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class ShopCell : MonoBehaviour
{
    public Action OnBuy;
    [SerializeField] private TextMeshProUGUI _name, _cost;
    [SerializeField] private Image _icon;
    private IShopItem _item;
    private bool _selected = true;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        _selected = CheckBool();
       
    }
    public void Render(IShopItem item)
    {

        if (item.IsBuyed) _name.text = "Куплено";
        else _name.text = item.Name;
        
        _cost.text = item.Cost.ToString();
        _icon.sprite = item.Image;
        _item = item;
        if (item.Name == "PM" || item.Name == "TEC-9" )
        {
            _icon.transform.localScale = new Vector3(0.7f, 1f, 0.7f);
        }
        else if( item.Name == "Grenade")
        {
            _icon.transform.localScale = new Vector3(0.5f, 1f, 0.5f);
        }
      
           
    }
    public bool CheckBool()
    { 
        if (true)
        {
            OnBuy?.Invoke();
            Debug.Log("В");
            return false;
        }
       
    }
    public void Buy()
    {
        if (_item.IsBuyed)
        {
            _item.OnBuy();
            OnBuy?.Invoke();
            return;
        }
        var wallet = PlayerMotor.Singleton.GetComponent<Wallet>();
        if (wallet.Money < _item.Cost) return;
        wallet.SpendMoney(_item.Cost);
        _item.OnBuy();
        OnBuy?.Invoke();
    }
    
}
