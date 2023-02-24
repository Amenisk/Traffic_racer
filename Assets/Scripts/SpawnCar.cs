using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    [SerializeField] private GameObject _car;
    [SerializeField] private List<Transform> _spawnLines;
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    public static int[] LineOccupancy = new int[5];

    private float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < LineOccupancy.Length; i++)
        {
            LineOccupancy[i] = 0;
        }
        Game.Points = 0;
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
            var numberLine = Random.Range(0, _spawnLines.Count);
            var numLine = numberLine % 5;
            if (LineOccupancy[numLine] < 2)
            {
                LineOccupancy[numLine]++;
                _car.transform.position = new Vector3(0, 0, 0);
                Instantiate(_car, _spawnLines[numberLine]);
                _car.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
                var imageBoundsSize = _car.GetComponent<SpriteRenderer>().sprite.bounds.size;
                _car.GetComponent<CapsuleCollider2D>().size = imageBoundsSize;
                _car.transform.position = new Vector3(_car.transform.position.x - 3f, _car.transform.position.y, _car.transform.position.z);
            }   

            yield return new WaitForSeconds(time);
        }
    }
}
