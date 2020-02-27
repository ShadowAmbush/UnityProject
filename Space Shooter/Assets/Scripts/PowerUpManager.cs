using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _tripleShotPowerUpprefab;
    [SerializeField]
    private GameObject _PowerUpContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PowerUpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PowerUpRoutine()
    {
        float randomX = Random.Range(-9.4f, 9.4f);
        while (_stopSpawning == false)
        {
            GameObject newPowerUp = Instantiate(_tripleShotPowerUpprefab, transform.position = new Vector3(randomX, 6, 0), Quaternion.identity);
            newPowerUp.transform.parent = _PowerUpContainer.transform;
            yield return new WaitForSeconds(30);
        }
    }
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
