using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _TripleShotPowerUpprefab;
    [SerializeField]
    private GameObject[] powerups;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        float randomX = Random.Range(-9.4f, 9.4f);
        int randomS = Random.Range(5,12);
        //every 3-7 seconds spawn a power-up
        while(_stopSpawning == false)
        {
            int randomPowerUp = Random.Range(0,3);
            GameObject newPowerUp = Instantiate(powerups[randomPowerUp], transform.position = new Vector3(randomX, 6, 0), Quaternion.identity);
            yield return new WaitForSeconds(randomS);

        }
    }

    IEnumerator SpawnEnemyRoutine()
    {
        float randomX = Random.Range(-9.4f, 9.4f);
        while (_stopSpawning == false)
        {
           GameObject newEnemy = Instantiate(_enemyprefab, transform.position = new Vector3(randomX, 6, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
