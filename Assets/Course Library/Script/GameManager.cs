using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> target;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreTest;
    private int score;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, target.Count);
            Instantiate(target[index]);
            UpdateScore(5);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
        scoreTest.text = "Score: " + score;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreTest.text = "Score: " + score;
        
    }
    public void GameOver()

    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()

    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
