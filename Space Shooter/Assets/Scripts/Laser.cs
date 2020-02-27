using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    //speed variable = 8
    [SerializeField]
    private float _speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }
    void CalculateMovement()
    {
        //translate laser up
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y >= 7)
        {
            Destroy(this.gameObject);
        }
    }
}
