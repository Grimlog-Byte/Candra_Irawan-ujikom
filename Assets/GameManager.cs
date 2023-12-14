using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int _currentScore;
    [SerializeField] TextMeshProUGUI scoreTextUI;

    [SerializeField] float levelTimeCounter = 60f;
    [SerializeField] TextMeshProUGUI levelTimeCounterTextUI;
    [SerializeField] GameObject resultPanel;

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] bool canSpawn = true;
    [SerializeField] float spawnCount = 2f;
    [SerializeField] float currentSpawnCounter;

    public GameObject[] animals;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {

        levelTimeCounter -= Time.deltaTime;
        levelTimeCounterTextUI.text = "Time: " + ((int)levelTimeCounter).ToString();
        if (canSpawn)
        {
            StartCoroutine(AnimalSpawnerCounter());
        }
    
        if(levelTimeCounter <= 0)
        {
          
            GameOver();
        }
    }

    public void GameOver()
    {
        resultPanel.SetActive(true);
        Time.timeScale = 0;
    }

   

    public void AddScore(int score)
    {
        _currentScore += score;
        UpdateScoreUI();

}

    private void UpdateScoreUI()
    {
        scoreTextUI.text =  "Score: " + _currentScore.ToString();
    }


    private void SpawnAnimal()
    {
        int animalID = Random.Range(0, animals.Length);
        int spawnPointID = Random.Range(0, spawnPoints.Length);
        Instantiate(animals[animalID], spawnPoints[spawnPointID].position, Quaternion.identity);
    }

    IEnumerator AnimalSpawnerCounter()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnCount);
        canSpawn = true;
        SpawnAnimal();
    }

}
