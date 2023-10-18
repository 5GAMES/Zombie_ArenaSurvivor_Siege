using System.Threading.Tasks;
using UnityEngine;

public class GrenadeHandler : MonoBehaviour
{
    [SerializeField] private Grenade grenadePrefab;
    [SerializeField] private GameObject _grenadeThrowPoint;
    private bool _onCooldown = false;
    public int GrenadeCout = 1;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(GrenadeCout > 0)
            {
                Throw();
            }
            
        }

        
    }

    private async void Throw()
    {
        if (_onCooldown) return;
        _onCooldown = true;
        Grenade grenade = Instantiate(grenadePrefab, _grenadeThrowPoint.transform.position, Quaternion.identity);
        grenade.Throw(transform.forward);
        await Task.Delay(5000);
        _onCooldown = false;
    }


}
