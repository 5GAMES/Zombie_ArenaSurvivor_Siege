using UnityEngine;
using TMPro;

[RequireComponent(typeof(Weapon))]
public class WeaponUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI _textmagazin;

    private void Start() =>
        GetComponent<Weapon>().OnMagazineValueChnaged += Render;

    private void Render(int value) => _textmagazin.text = value.ToString();
}
