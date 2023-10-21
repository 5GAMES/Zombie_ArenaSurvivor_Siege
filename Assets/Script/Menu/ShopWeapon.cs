using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon")]
public class ShopWeapon : ShopItem
{
    [SerializeField] private Weapon _weapon;
    public Weapon Instance { get { return _weapon; } }
    public override void OnBuy()
    {
        base.OnBuy();
        PlayerMotor.Singleton.GetComponent<WeaponHandler>().SetWeapon(this);
    }
}
