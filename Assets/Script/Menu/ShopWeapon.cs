using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon")]
public class ShopWeapon : ShopItem
{
    [SerializeField] private Weapon _weapon;

    public override void OnBuy()
    {
        base.OnBuy();
        PlayerMotor.Singleton.GetComponent<WeaponHandler>().SetWeapon(_weapon);
    }
}
