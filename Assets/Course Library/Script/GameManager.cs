using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> target;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreTest;
    private int score;
    IEnumerator SpawnTarget()
    {
        while (true) 
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
}
