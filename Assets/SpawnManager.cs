using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import Unity UI namespace

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
    private int score = 0; // Score variable
    public Text scoreText; // Reference to UI text object

    // Start is called before the first frame update
    void Start()
    {
        // Find and assign the UI text object
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        // Set initial score
        UpdateScoreUI();
        SpawnEnemy(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemy(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemy(int enemiestospawn)
    {
        for (int i = 0; i < enemiestospawn; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            newEnemy.GetComponent<Enemy>().spawnManager = this;
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    public void IncreaseScore()
    {
        score++;
        // Update UI text
        UpdateScoreUI();
    }

    // Method to update UI text with the score
    void UpdateScoreUI()
    {
        scoreText.text =  score.ToString();
    }
}
