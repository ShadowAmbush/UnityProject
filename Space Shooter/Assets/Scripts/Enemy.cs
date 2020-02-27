using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        //if bottom of screen
        //respawn at top with a random x position
        if(transform.position.y <= -5.5)
        {
            float randomX = Random.Range(-9.4f, 9.4f);
            transform.position = new Vector3(randomX,6,0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //if other is Player
        if(other.tag == "Player")
        {
            //damage the player
            Player player = other.transform.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }


            //Destroy us
            Destroy(this.gameObject);
        }




        //if other is Laser
        if (other.tag == "Laser")
        {
            //destroy laser
            Destroy(other.gameObject);
            //destroy us
            Destroy(this.gameObject);
        }

        
        
        
    }
    
}
