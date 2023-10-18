using System.Threading.Tasks;
using UnityEngine;

public class GrenadeHandler : MonoBehaviour
{
    [SerializeField] private Grenade grenadePrefab;
    [SerializeField] private GameObject _grenadeThrowPoint;
    [SerializeField]private int _genadeCout = 1;
    [SerializeField] private int _maxGrenade;
    public int MaxGrenadeCount { get { return _maxGrenade; } }
    private bool _onCooldown = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(_genadeCout > 0)
            {
                Throw();
            }
        }
    }

    private async void Throw()
    {
        if (_onCooldown) return;
        _genadeCout--;
        _onCooldown = true;
        Grenade grenade = Instantiate(grenadePrefab, _grenadeThrowPoint.transform.position, Quaternion.identity);
        grenade.Throw(transform.forward);
        await Task.Delay(5000);
        _onCooldown = false;
    }

    public int AddGrenade()
    {
        if(_genadeCout + 1 <= _maxGrenade) _genadeCout++;
        return _genadeCout;
    }


}
