using UnityEngine;

[CreateAssetMenu(menuName = "Items/Grenade")]
public class ShopGrenade : ShopItem
{
    public override void OnBuy()
    {
        var handler = PlayerMotor.Singleton.GetComponent<GrenadeHandler>();
        if(handler.AddGrenade() >= handler.MaxGrenadeCount)base.OnBuy();
    }

    public void CheckAllBuyed()
    {
        var handler = PlayerMotor.Singleton.GetComponent<GrenadeHandler>();
        if (handler.CurrentGrenadeCount < handler.MaxGrenadeCount) _isBuyed = false;
        else _isBuyed = true;
    }
}
