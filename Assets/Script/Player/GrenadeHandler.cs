using System.Collections;
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
    [SerializeField] private GamaManager _gamaManager;
    public int MaxGrenadeCount { get { return _maxGrenade; } }
    public int CurrentGrenadeCount { get { return _genadeCout; } }
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
                
                StartCoroutine(Throw());
            }
            else
            {
               StartCoroutine(OverGrenade());
            }
            
        }
    }

    private IEnumerator Throw()
    {
        if (_onCooldown) yield break;
        _genadeCout--;
        print(_genadeCout);
        _textCoutGrenade.text = _genadeCout.ToString();
        _onCooldown = true;
        Grenade grenade = Instantiate(grenadePrefab, _grenadeThrowPoint.transform.position, Quaternion.identity);
        grenade.Throw(transform.forward);
        yield return new WaitForSeconds(1f);
        _onCooldown = false;
        
       
    }
    private IEnumerator OverGrenade()
    {
        _gamaManager.Texthelp("Гранаты закончились");
        yield return new WaitForSeconds(1f);
        _gamaManager.Texthelp("");
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
