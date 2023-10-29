using UnityEngine;

[CreateAssetMenu(menuName = "Items/Grenade")]
public class ShopGrenade : ShopItem
{
    private GrenadeHandler handler;

    public override void OnBuy() =>
            CheckAllBuyed();

    public void CheckAllBuyed()
    {
        handler = PlayerMotor.Singleton.GetComponent<GrenadeHandler>();
        if (handler.CurrentGrenadeCount < handler.MaxGrenadeCount)
        {
            _isBuyed = false;
            handler.AddGrenade();
        }
        else _isBuyed = true;
    }
}
