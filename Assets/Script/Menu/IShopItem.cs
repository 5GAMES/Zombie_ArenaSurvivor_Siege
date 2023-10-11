using UnityEngine;

public interface IShopItem
{
    Sprite Image { get; }
    string Name { get; } 
    bool IsBuyed { get; }
    int Cost { get; }
}
