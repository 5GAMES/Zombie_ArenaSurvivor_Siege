using UnityEngine;

public interface IShopItem
{
    Sprite Image { get; }
    string Name { get; } 
    bool IsBuyed { get; set; }
    int Cost { get; }
    public void OnBuy();
}
