using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace YG.Example
{
    public class SaverTest : MonoBehaviour
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
            for (int i = 0; i < _shop.Item.Count; i++)
            {
              var weapon = (IShopItem)_shop.Item[i];
              weapon.IsBuyed = YandexGame.savesData.Weapon[i];

            }
            _wallet.Money = YandexGame.savesData.Money;
            _playerLook.xSensitivity = YandexGame.savesData.SensitivitySlider;
            _playerLook.UpdateSensitivity(_playerLook.xSensitivity);
            ZombieCounter.SetStat(YandexGame.savesData.ZombieCount);
            _gameManager.IsStartGame = YandexGame.savesData.IsStartGame;
            print("Load" + _wallet.Money);
            print("Load" + ZombieCounter.ZombieKilled);
            print("Load" + _playerLook.xSensitivity);
        }
        public void Load() => YandexGame.LoadLocal();
        public void Save()
        {
            YandexGame.savesData.SensitivitySlider = _playerLook.xSensitivity;
            YandexGame.savesData.Money = _wallet.Money;
            YandexGame.savesData.ZombieCount = ZombieCounter.ZombieKilled;
            YandexGame.savesData.IsStartGame = _gameManager.IsStartGame;
            _shop.Item.Clear();
            for (int i = 0; i < _shop.Item.Count; i++)
            {
                var weapon = (IShopItem)_shop.Item[i];
                YandexGame.savesData.Weapon[i] = weapon.IsBuyed;
            }
            print("Save" + _wallet.Money);
            print("Save" + ZombieCounter.ZombieKilled);
            YandexGame.SaveCloud();
        }
    }
}