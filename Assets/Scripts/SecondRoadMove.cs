using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SecondRoadMove : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.0f)
        {
            return;
        }
        var target = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, _movementSpeed);
        if(transform.localPosition.y <= -22.93f)
        {
            transform.position = new Vector3(transform.position.x, 21.05f, transform.position.z);
        }
    }
}
