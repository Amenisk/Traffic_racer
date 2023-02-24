using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    private float _movementSpeed;
    private float _carMove;
    public int NumberLine = -1;
    // Start is called before the first frame update
    void Start()
    {
        _movementSpeed = 0.05f;
        if (transform.position.y <= 0f)
        {
            _carMove = Random.Range(0.01f, 0.05f);
        }
        else
        {
            _carMove = Random.Range(-0.01f, -0.05f);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.0f)
        {
            return;
        }
        var target = new Vector3(transform.position.x, transform.position.y + _carMove, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, _movementSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "Car")
        {
            Time.timeScale = 0.0f;
            Destroy(gameObject);
            return;
        }
        var target = transform.position.x;

        if (target > -3f && target <= -2f)
        {
            SpawnCar.LineOccupancy[0]--;
        }
        else if(target > -2f && target <= -0.7f)
        {
            SpawnCar.LineOccupancy[1]--;
        }
        else if(target > -0.7f && target <= 1f)
        {
            SpawnCar.LineOccupancy[2]--;
        }
        else if (target > 1f && target <= 2.5f)
        {
            SpawnCar.LineOccupancy[3]--;
        }
        else if (target > 2.5f && target <= 4f)
        {
            SpawnCar.LineOccupancy[4]--;
        }

        Destroy(gameObject);
    }
}
