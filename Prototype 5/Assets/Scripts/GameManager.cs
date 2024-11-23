/*
Name: John Chirayil
File: GameManager.cs
Assignment 8 - Prototype 5
Description: This code manages the overall game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton; 

    private int score;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            // Wait 1 second
            yield return new WaitForSeconds(spawnRate);

            // Pick a random index betwwen 0 and the number of prefabs
            int index = Random.Range(0, targets.Count); 

            // Spawn the prefab at the random selected index
            Instantiate(targets[index]);

            // testing UpdateScore by adding 5 every time a new target spawns
            //UpdateScore(5);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
