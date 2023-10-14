using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public Action<int> OnValueChanged;
    [SerializeField] private int _money;
    public int Money { get { return _money; } }

    private void Start() => OnValueChanged?.Invoke(_money);

    public void AddMoney(int value)
    {
        _money += value;
        OnValueChanged?.Invoke(_money);
    }

    public void SpendMoney(int value)
    {
        if (_money - value < 0) return;
        _money -= value;
        OnValueChanged?.Invoke(_money);
    }
}
