using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponParameters", menuName = "WeaponParametersSO")]
public class WeaponParametersSO : ScriptableObject
{

        
        public float damage;
        public float range;
        public float impactForce;
        public float fireRate;
        public float magazine;
        public float magazineCapacity;
        public float _audioclips;
}
