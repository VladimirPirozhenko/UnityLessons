using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float delayBeforeSpawn;
    // Start is called before the first frame update
    private Vector2 screenBounds;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    void Spawn()
    {
        Enemy enemy = Instantiate(enemyPrefab);
        enemy.transform.position = new Vector3(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y)); 
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayBeforeSpawn);
            Spawn();
        }
    }
}
