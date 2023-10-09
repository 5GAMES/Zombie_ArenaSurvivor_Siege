using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponParameters", menuName = "WeaponParametersSO")]
public class WeaponParametersSO : ScriptableObject
{
        public float damage;
        public float range;
        public float impactForce;
        public float fireRate;
        public int magazine;
        public int magazineCapacity;
        public float _audioclips;
}
