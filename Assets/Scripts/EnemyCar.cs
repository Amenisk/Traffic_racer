using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    private float _movementSpeed;
    private float _carMove;
    // Start is called before the first frame update
    void Start()
    {
        _movementSpeed = 0.05f;
        if (transform.position.y <= 0f)
        {
            _carMove = Random.Range(0.001f, 0.01f);
        }
        else
        {
            _carMove = Random.Range(-0.001f, -0.01f);
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        var target = new Vector3(transform.position.x, transform.position.y + _carMove, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, _movementSpeed);
    }
}
