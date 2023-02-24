using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0.0f)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(transform.position.x > -2.77f)
            {
                var target = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target, _movementSpeed);
            }       
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x < 3.23f)
            {
                var target = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target, _movementSpeed);
            }
        }
    }

}
