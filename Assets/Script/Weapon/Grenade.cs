using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float _damage, _throwForce = 10f, _explosionRadius = 5f, _explosionForce = 700f, _lifeTime = 3f;
    [SerializeField] ParticleSystem _particleSystem;
    private bool isExploded = false;

    public void Throw(Vector3 direction) => GetComponent<Rigidbody>().AddForce(direction * _throwForce, ForceMode.Impulse);

    private void OnCollisionEnter(Collision collision) => GetComponent<Rigidbody>().isKinematic = true;

    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        _particleSystem.Play();
        yield return new WaitForSeconds(_lifeTime);
        Explode();
    }

    private void Explode()
    {
        if (isExploded) return;
        isExploded = true;

        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }

            Target health = nearbyObject.GetComponent<Target>();
            if (health != null)
            {
                health.TakeDamage(50);
            }
        }
        Destroy(this.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }

}
