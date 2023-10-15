using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject _weaponHandle, _shootPoint;

    public void SetWeapon(Weapon weapon)
    {
        if(_weaponHandle.transform.childCount != 0)
        {
            foreach(Transform child in _weaponHandle.transform)
            {
                if(child.name != _shootPoint.name)Destroy(child.gameObject);
            }
        }

        GameObject instance = Instantiate(weapon.gameObject, _weaponHandle.transform);
        instance.transform.position = _weaponHandle.transform.position;
        var weap = instance.GetComponent<Weapon>();
        weap.BulletInstancer = _shootPoint;
    }
}
