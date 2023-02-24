using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _pointsScore;
    public static int Points;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountPoints());
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.0f)
        {
            _canvas.SetActive(true);
        }
        _pointsScore.GetComponent<Text>().text = Points.ToString();
    }

    public void RestartGame()
    {
        _canvas.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    private IEnumerator CountPoints()
    {
        while(true)
        {
            Points++;
            yield return new WaitForSeconds(1f);
        }    
    }
}
