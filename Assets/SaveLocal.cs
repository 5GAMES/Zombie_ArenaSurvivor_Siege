using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SaveLocal : MonoBehaviour
{
    [SerializeField] private GamaManager _gameManager;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerLook _playerLook;
    [SerializeField] private Shop _shop;
    [SerializeField] private ShopCell _cell;
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        
    }
    private void Awake()
    {

        if (YandexGame.SDKEnabled)
            GetLoad();
    }
    public void GetLoad()
    {
        
        for (int i = 0; i < _shop.Item.Count; i++)
        {
            if (YandexGame.savesData.Weapon.Count == 0) break;
            var weapon = (IShopItem)_shop.Item[i];
            weapon.IsBuyed = YandexGame.savesData.Weapon[i];
        }
        _gameManager.IsFirstGame = YandexGame.savesData.IsStartGame;
        _wallet.Money = YandexGame.savesData.Money;
        _playerLook.xSensitivity = YandexGame.savesData.SensitivitySlider;
        _playerLook.UpdateSensitivity(_playerLook.xSensitivity);
        ZombieCounter.SetMax(YandexGame.savesData.ZombieCoutMax);
        ZombieCounter.SetStat(YandexGame.savesData.ZombieCount);

    }
    public void Load() => YandexGame.LoadLocal();
    public void Save()
    {
        YandexGame.savesData.SensitivitySlider = _playerLook.xSensitivity;
        YandexGame.savesData.Money = _wallet.Money;
        YandexGame.savesData.ZombieCoutMax = ZombieCounter.ZombieKilledMax;
        YandexGame.savesData.ZombieCount = ZombieCounter.ZombieKilled;
        YandexGame.savesData.IsStartGame = _gameManager.IsFirstGame;
        
        var weapon = _shop.Item;
        List<bool> www = new();
        for (int i = 0; i < _shop.Item.Count; i++)
        {
            var ddf = (IShopItem)weapon[i];
            www.Add(ddf.IsBuyed);
            
        }
        YandexGame.savesData.Weapon = new List<bool>(www);
        YandexGame.SaveLocal();
    }
}
