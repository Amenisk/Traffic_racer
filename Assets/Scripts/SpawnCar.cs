using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    [SerializeField] private GameObject _car;
    [SerializeField] private GameObject _SpawnLines;
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    private float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private IEnumerator SpawnCars()
    {
        while(true)
        {
            var enemyCar = Instantiate(_car, gameObject.transform.GetChild(Random.Range(0, 10)));
            enemyCar.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];

            var imageBoundsSize = enemyCar.GetComponent<SpriteRenderer>().sprite.bounds.size;
            enemyCar.GetComponent<CapsuleCollider2D>().size = imageBoundsSize;

            yield return new WaitForSeconds(time);
        }
    }
}
