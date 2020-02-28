using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserprefab;
    [SerializeField]
    private float _firerate = .5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    private PowerUpManager _powerUpManager;
    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private GameObject _tripleprefab;

    public float GetSpeed()
    {
        return _speed;
    }
    public void SetSpeed(int speed)
    {
        _speed = speed;
        StartCoroutine(SpeedPowerUpDownRoutine());
    }
    // Start is called before the first frame update
    void Start()
    {

        //take the current position = new position(0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if( _spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        //if time that has passed is greater than the value of canFire, then instantiate
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
           FireLaser();
        }
       
    }
    void FireLaser()
    {
        if(_isTripleShotActive == true)
        {
            _canFire = Time.time + _firerate;
            Instantiate(_tripleprefab, transform.position + new Vector3(-0.715f, -0.29f, 0), Quaternion.identity);

        }
        else if(_isTripleShotActive == false)
        {
            //after firing, canFire will take the value of time elapsed + cooldown, so that the player can fire again, after the cooldown
            _canFire = Time.time + _firerate;
            Instantiate(_laserprefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
       
        //after firing, canFire will take the value of time elapsed + cooldown, so that the player can fire again, after the cooldown
        

        //if space key press,

        //if tripleshotActive is true
            //fire 3 lasers (triple shot prefab)

        //else fire 1 laser

    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);


        //if player position on the Y is greater than zero
        //Y position = 0
        //else if position on the y is less than 3.8f
        //y pos = -3.8f
        //using Mathf.Clamp to set a min and a max value to the Y pos


        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
       
        
        //if player on the x > 11
        //x pos = -11
        //else if player on the x < -11
        //x pos = 11

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }

    }
    public void Damage()
    {
        _lives--;
        //check if dead
        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            _powerUpManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotDownRoutine());
    }
    IEnumerator TripleShotDownRoutine()
    {
        yield return new WaitForSeconds(5);
        _isTripleShotActive = false;
    }
    IEnumerator SpeedPowerUpDownRoutine()
    {
        yield return new WaitForSeconds(5);
        _speed = 5;
    }
}
