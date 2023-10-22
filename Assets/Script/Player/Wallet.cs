using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public Action<int> OnValueChanged;
    [SerializeField] private int _money;
    [SerializeField] private Save _save;
    public int Money { get { return _money; } }

    private void OnDestroy() => _save.Cash = _money;
    private void Start()
    {
        ZombieCounter.Saver = _save;
        ZombieCounter.SetStat(_save.KilledZombie);
        _money = _save.Cash;
        OnValueChanged?.Invoke(_money);
    }

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
