using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

   
    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(-9.4f, 9.4f);
        transform.position = new Vector3(randomX, 6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        //move down at a speed of 3
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //destroy when we leave the screen

        if (transform.position.y <= -5.5)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if(player != null)
            {
                player.TripleShotActive();
            }
            Destroy(this.gameObject);
        }

    }
  
}
