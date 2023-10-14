using TMPro;
using UnityEngine;

public class WeaponUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tex;
    public TextMeshProUGUI MagazinTExt { get {  return _tex; } }
}
