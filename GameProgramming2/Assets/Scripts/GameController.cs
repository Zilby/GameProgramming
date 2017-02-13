using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private int score;
    private bool gameover;
    private bool restart;

    private void Start()
    {
        score = 0;
        gameover = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        for (;;)
        {
            if (gameover)
            {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int i)
    {
        score += i;
        UpdateScore();
    }

    public void GameOver()
    {
        gameover = true;
        gameOverText.text = "Game Over";
    }

    private void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown (KeyCode.R))
            {
                SceneManager.LoadScene("Main");
                //Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
