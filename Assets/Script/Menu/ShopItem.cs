using UnityEngine;

[CreateAssetMenu(menuName ="Items/Asset")]
public class ShopItem : ScriptableObject, IShopItem
{
    public bool IsBuyed => _isBuyed;
    Sprite IShopItem.Image => _image;
    string IShopItem.Name => _name;
    public int Cost => _cost;

    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _cost;
    [SerializeField]private bool _isBuyed = false;
    public void OnBuy()
    {
        _isBuyed = true;
    }
}
