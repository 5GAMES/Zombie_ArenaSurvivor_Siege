using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GrenadeHandler : MonoBehaviour
{
    [SerializeField] private Grenade grenadePrefab;
    [SerializeField] private GameObject _grenadeThrowPoint;
    [SerializeField] private int _genadeCout = 2;
    [SerializeField] private int _maxGrenade = 5;
    [SerializeField] TextMeshProUGUI _textCoutGrenade;
    public int MaxGrenadeCount { get { return _maxGrenade; } }
    private bool _onCooldown = false;
    private void Start()
    {
       _textCoutGrenade.text = _genadeCout.ToString();
    }
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
        _textCoutGrenade.text = _genadeCout.ToString();
        _onCooldown = true;
        Grenade grenade = Instantiate(grenadePrefab, _grenadeThrowPoint.transform.position, Quaternion.identity);
        grenade.Throw(transform.forward);
        await Task.Delay(5000);
        _onCooldown = false;
       
    }
    public int AddGrenade()
    {
        if(_genadeCout <= _maxGrenade)
        {
            _genadeCout++;
            _textCoutGrenade.text = _genadeCout.ToString();
        }
        return _genadeCout;
        
        
        
    }


}
