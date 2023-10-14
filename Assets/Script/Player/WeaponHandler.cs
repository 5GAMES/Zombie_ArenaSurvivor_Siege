using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject _weaponHandle;

    public void SetWeapon(Weapon weapon)
    {
        if(_weaponHandle.transform.childCount != 0)
        {
            foreach(Transform child in _weaponHandle.transform) Destroy(child.gameObject);
        }

        var instance = Instantiate(weapon.gameObject, _weaponHandle.transform);
        instance.transform.position = _weaponHandle.transform.position;
    }
}
