using UnityEngine;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Image _weaponUI;
    [SerializeField] private GameObject _weaponHandle, _shootPoint;

    public void SetWeapon(ShopWeapon weapon)
    {
        if(_weaponHandle.transform.childCount != 0)
        {
            foreach(Transform child in _weaponHandle.transform)
            {
                if(child.name != _shootPoint.name)Destroy(child.gameObject);
            }
        }

        GameObject instance = Instantiate(weapon.Instance.gameObject, _weaponHandle.transform);
        instance.transform.position = _weaponHandle.transform.position;
        var weap = instance.GetComponent<Weapon>();
        weap.BulletInstancer = _shootPoint;
        var item = (IShopItem)weapon;
        _weaponUI.sprite = item.Image;
    }
}
