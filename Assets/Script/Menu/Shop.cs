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
    [SerializeField] private Transform _container;
    [SerializeField] private ShopCell _cell;
    [SerializeField] private List<ShopItem> _items;

    private void OnEnable()
    {
        Render();
    }

    private void Render()
    {
        foreach(Transform child in _container) Destroy(child.gameObject);
        
        foreach(var item in  _items)
        {
            var cell = Instantiate(_cell, _container);
            cell.Render(item);
            cell.OnBuy += SetBuyedItem;
        }

    }

    private void SetBuyedItem()
    {
        _buyButton.interactable = false;
        _buyButton.GetComponentInChildren<Text>().text = "Куплено";
    }

    public void Forward()
    {

    }

    public void Back()
    {

    }

    public async void Buy()
    {

    }
}
