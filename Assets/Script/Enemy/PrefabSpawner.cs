
using UnityEngine;
using TMPro;
public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawnMagazin;
    public GameObject[] prefabToSpawnWeapon;
    public Transform playerTransform;
    [SerializeField] MenuMagazin menuMagazin;
    [SerializeField] GameManager gameManager;
    [SerializeField] PauseMenu _pauseMenu;
 
    
    [Header("Save")]
    //private SaverData _averData;
    bool[] purchasedItems = new bool[7];
    private void Awake()
    {
         
    }
    void Start()
    {
        //_averData = FindObjectOfType<SaverData>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Update()
    {
        
        
       
    }
    public void OpenShop()
    {
        Vector3 spawnPosition = new Vector3(5.88f, -18.9762516f, 9.19999981f);
        GameObject newPrefab = Instantiate(prefabToSpawnMagazin, spawnPosition, Quaternion.identity);
        
    }
    public void CloseShop()
    {
        FindObjectOfType<DestroyMagazin>().Destroy();
       
    }
    
    public void BuyWeapon()
    {
        
        int currentIndex = menuMagazin.currentIndex;
        int[] prices = menuMagazin.prices;
        // Создайте массив для отслеживания купленных предметов
        if (currentIndex >= 0 && currentIndex < prices.Length)
        {
            if (!purchasedItems[currentIndex] && gameManager._money >= prices[currentIndex])
            {
                gameManager._money -= prices[currentIndex];
                
                Vector3 spawnPosition = playerTransform.position;
                GameObject newPrefab = Instantiate(prefabToSpawnWeapon[currentIndex], spawnPosition, Quaternion.identity);
                newPrefab.transform.SetParent(playerTransform);
               // FindObjectOfType<CheckingWeapons>().curentcurrentweapons();
                // Пометьте предмет как купленный
                Debug.Log("menuMagazin.prices[currentIndex] = " + menuMagazin.prices[currentIndex]);
                for (int i = 0; i < menuMagazin.prices.Length; i++)
                {
                    if (menuMagazin.prices[i] == prices[currentIndex])
                    {
                        menuMagazin.prices[i] = 0;
                        Debug.Log("menuMagazin.prices[i] = " + menuMagazin.prices[i] + "prices[currentIndex]" + prices[currentIndex]);
                    }    
                }
                //menuMagazin.prices[currentIndex] = 0;
                Debug.Log("menuMagazin.prices[currentIndex] = " + menuMagazin.prices[currentIndex]);
                purchasedItems[currentIndex] = true;
                
           //  _averData.Save();
            }
            else if (purchasedItems[currentIndex])
            {
                Debug.Log("Предмет уже куплен");
                Vector3 spawnPosition = playerTransform.position;
                GameObject newPrefab = Instantiate(prefabToSpawnWeapon[currentIndex], spawnPosition, Quaternion.identity);
                newPrefab.transform.SetParent(playerTransform);
                //FindObjectOfType<CheckingWeapons>().curentcurrentweapons();
                
                

            }
            else
            {
                Debug.Log("Деньги давай");
                Debug.Log(currentIndex);
            }
        }
        else
        {
            Debug.Log("Недопустимый индекс предмета");
        }
        gameManager.textmoney.text = gameManager._money.ToString();
        
    }


}
