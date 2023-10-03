using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // ������ �������� ������ ��� ������
    public Transform[] spawnPoints; // ������ ����� ������
    public GameObject[] EnemyPoints;
    public float spawnInterval = 2f; // �������� ����� ������� ������
    private float spawnTimer = 2f; // ������ ��� ������� �������
    private int enemyCount = 0;

    [Header("Waves")]
    private float textwaves;
    [SerializeField] private float WavesCout;
    [SerializeField] private int MaxEnemy;
    [SerializeField] private Image wavesCountImage;
    [SerializeField] TextMeshProUGUI _textWaves;
    [SerializeField] private GameObject _WavesImage;

    [SerializeField] PlayerHealthBar _playerHealthBar;

    [Header("SaverData")]
    [SerializeField] private SaverData _saverData;
    private void Update()
    {
        SearchEnemy();

        
       
       
    }
    private void Start()
    {
        
   
        MaxEnemy = 1;
        WavesCout = 10f;
       // _textWaves.text = textwaves.ToString();
    }

    private void SpawnRandomEnemy()
    {
        if (enemyCount < MaxEnemy)
        {
            // �������� ��������� ������ ����� �� �������
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // �������� ��������� ����� ������ �� �������
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // ������� ������ ����� �� ��������� ����� ������ � ��������� ��������
            Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);
            FindObjectOfType<Enemy>().RandomPath();
            enemyCount++;
        }
        
    }
    private void SearchEnemy()
    {
        if (textwaves >= 0f)
        {

            if (_playerHealthBar._health != 100)
            {
                _playerHealthBar.RestoreHealth(100);
            }
            textwaves -= Time.deltaTime * 1f;
            wavesCountImage.fillAmount = (float)textwaves / 10f;
        }
        else if (FindObjectOfType<Enemy>() == null && enemyCount >= MaxEnemy)
        {
            
            _WavesImage.SetActive(true);
            textwaves = WavesCout;
    
            wavesCountImage.fillAmount = (float)textwaves / 10f;
            enemyCount = 0;
            MaxEnemy += 2;
            
            _saverData.Save();
        }
        else if (textwaves <= 0f)
        {
            _WavesImage.SetActive(false);
            spawnTimer += Time.deltaTime;

            // ���� ������ ���������� ������� ��� ������ ������ �����
            if (spawnTimer >= spawnInterval)
            {
                // �������� ����� ��� ������ ���������� �����

                SpawnRandomEnemy();
                // ���������� ������
                spawnTimer = 0f;
            }
           
        }
       
    }
    
}
