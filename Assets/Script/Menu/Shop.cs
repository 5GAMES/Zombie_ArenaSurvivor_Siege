using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Links : ")]
    [SerializeField] private Image _image;
    [SerializeField] private Text _name;
    [SerializeField] private Button _buyButton;
    [SerializeField] private List<ShopItem> _items;
    private int _index = 0;

    private void OnEnable()
    {
        _index = 0;
        Render(_items[_index]);
    }

    private void Render(IShopItem item)
    {
        _image.sprite = item.Image;
        _name.text = item.Name;
        if (item.IsBuyed) SetBuyedItem();
        else
        {
            _buyButton.interactable = true;
            _buyButton.GetComponentInChildren<Text>().text = "Купить";
        }
    }

    private void SetBuyedItem()
    {
        _buyButton.interactable = false;
        _buyButton.GetComponentInChildren<Text>().text = "Куплено";
    }

    public void Forward()
    {
        if (_index < _items.Count - 1) _index++;
        else _index = 0;
        Render(_items[_index]);
    }

    public void Back()
    {
        if(_index > 0)_index--;
        else _index = _items.Count - 1;
        Render(_items[_index]);
    }

    public async void Buy()
    {
        var wallet = PlayerMotor.Singleton.GetComponent<Wallet>();
        if (wallet.Money < _items[_index].Cost)
        { 
            var buttontext = _buyButton.GetComponentInChildren<Text>();
            var mainText = buttontext.text;
            buttontext.text = "Не достаточно средств";
            await Task.Delay(2000);
            buttontext.text = mainText;
        }
        else
        {
            wallet.SpendMoney(_items[_index].Cost);
            _items[_index].OnBuy();
            SetBuyedItem();
        }
    }
}
