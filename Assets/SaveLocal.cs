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
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent += GetLoad;


    private void Awake()
    {

        if (YandexGame.SDKEnabled)
            GetLoad();
    }
    public void GetLoad()
    {
       // for (int i = 0; i < _shop.Item.Count; i++)
       // {
            //var weapon = (IShopItem)_shop.Item[i];
            //weapon.IsBuyed = YandexGame.savesData.Weapon[i];

       // }
        _wallet.Money = YandexGame.savesData.Money;
        _playerLook.xSensitivity = YandexGame.savesData.SensitivitySlider;
        _playerLook.UpdateSensitivity(_playerLook.xSensitivity);
        ZombieCounter.SetStat(YandexGame.savesData.ZombieCount);
        _gameManager.IsStartGame = YandexGame.savesData.IsStartGame;
        print("Load Wallet:" + _wallet.Money);
        print("Load Cout" + YandexGame.savesData.ZombieCount);
        print("Load Sen" + _playerLook.xSensitivity);
    }
    public void Load() => YandexGame.LoadCloud();
    public void Save()
    {
        YandexGame.savesData.SensitivitySlider = _playerLook.xSensitivity;
        YandexGame.savesData.Money = _wallet.Money;
        YandexGame.savesData.ZombieCount = ZombieCounter.ZombieKilled;
        YandexGame.savesData.IsStartGame = _gameManager.IsStartGame;
        _shop.Item.Clear();
        //for (int i = 0; i < _shop.Item.Count; i++)
       // {
         //   var weapon = (IShopItem)_shop.Item[i];
           //YandexGame.savesData.Weapon[i] = weapon.IsBuyed;
       // }
        print("Save wallet" + _wallet.Money);
        print("Save cout" + ZombieCounter.ZombieKilled);
        YandexGame.SaveCloud();
    }
}
