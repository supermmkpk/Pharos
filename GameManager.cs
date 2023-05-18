using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 2f;

    private float countDown = 2f;

    private int waveIdx = 0;
    public Text timeText;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
        timeText.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Waver Incoming");
        waveIdx++;
        for (int idx = 0; idx < waveIdx; idx++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    
}
