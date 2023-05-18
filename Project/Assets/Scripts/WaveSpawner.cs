using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float waveTime = 10f;
    public TMP_Text waveCountdownText;


    private float countdown = 3f;
    private int waveNum = 1;
    private float spawnInterval = 0.5f;

    void Update() {
            if(countdown <= 0f) {
                StartCoroutine(spawnWave());
                countdown = waveTime;
            }
            countdown -= Time.deltaTime;

            waveCountdownText.text = System.Math.Round(countdown, 1).ToString();
    }

    IEnumerator spawnWave() {
        Debug.Log("Wave" + waveNum + " Start!");

        for(int i = 0; i < waveNum; i++) {
            //enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log(i+1);
            spawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }

        waveNum++;
    }

    void spawnEnemy() {
        float newX = Random.Range(-10f, 10f);
        float newZ = Random.Range(-100f, 100f);
        GameObject enemy = (GameObject)Instantiate(EnemyPrefab, new Vector3(newX, 0f, newZ), Quaternion.identity);
    }
}
