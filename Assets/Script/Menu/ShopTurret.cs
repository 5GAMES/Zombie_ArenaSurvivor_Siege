using UnityEngine;

public class ShopTurret : ShopItem
{
    [SerializeField] private Turret _turret;

    public override void OnBuy()
    {
        base.OnBuy();
        PlayerMotor.Singleton.GetComponent<TurretHandler>().SetTurret(_turret);
    }
}
