using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Enemy enmeyPrefab;
    public Transform Parent;

    public Text SpawnTimeLeft;

    private float GapBetweenWaveSpawning = 10f;

    private float Timer = 2f;

    private int WaveIndex = 0;

    public Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTimeLeft.text = Timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if(Timer<=0f)
        {
            StartCoroutine(SpawnWave());
            Timer = GapBetweenWaveSpawning;
        }

        Timer -= Time.deltaTime;
        Timer = Mathf.Clamp(Timer, 0f, Mathf.Infinity);
        SpawnTimeLeft.text = string.Format("{0:00.00}",Timer);
    }

    IEnumerator SpawnWave()
    {
        WaveIndex++;

        for(int i=0; i<WaveIndex;i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.8f);
        }
    }

    private void SpawnEnemy()
    {
        Enemy enmey=Instantiate<Enemy>(enmeyPrefab, spawnPoint, Quaternion.identity);
        enmey.transform.SetParent(Parent);
    }
}
