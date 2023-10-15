using UnityEngine;
using TMPro;

[RequireComponent(typeof(Weapon))]
public class WeaponUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI _textmagazin;

    private void Start()
    {
        GetComponent<Weapon>().OnMagazineValueChnaged += Render;
        SetText(PlayerMotor.Singleton.GetComponent<WeaponUIController>().MagazinTExt);
        Render(GetComponent<Weapon>().MagazinValue);
    }

    private void Render(int value) => _textmagazin.text = value.ToString();
    public void SetText(TextMeshProUGUI text)=> _textmagazin = text;
}
