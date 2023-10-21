using TMPro;
using UnityEngine;

public class UIEnemyDieCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterField;
    private void Start()
    {
        ZombieCounter.OnValueChanged += Render;
       // Render(ZombieCounter.ZombieKilled);
    }
    private void OnDestroy() => ZombieCounter.OnValueChanged -= Render;
    private void Render(int value) => _counterField.text = value.ToString();
}
