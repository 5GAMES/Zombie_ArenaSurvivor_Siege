using TMPro;
using UnityEngine;
using YG;

public class UIEnemyDieCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterField;
    private void Start()
    {
        ZombieCounter.OnValueChanged += Render;
       // Render(ZombieCounter.ZombieKilled);
    }
 
    private void OnDestroy() => ZombieCounter.OnValueChanged -= Render;
    public void Render(int value)
    {
        _counterField.text = value.ToString();
        
    }
        
}
