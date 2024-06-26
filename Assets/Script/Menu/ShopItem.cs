using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Asset")]
public class ShopItem : ScriptableObject, IShopItem
{
    public bool IsBuyed => _isBuyed;
    Sprite IShopItem.Image => _image;
    string IShopItem.Name => _name;
    public int Cost => _cost;

    bool IShopItem.IsBuyed { get => _isBuyed; set => _isBuyed = value; }

    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _cost;
    [SerializeField] protected bool _isBuyed = false;
    public virtual void OnBuy()
    {
        _isBuyed = true;
    }
    public void Refresh()
    {
        _isBuyed = false;
    }
}
