using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCheckBehaviour : MonoBehaviour
{
    private Queue<GameObject> _gameObjects;

    private DnaSequenceGenerator _dnaSequenceGenerator;

    public TextMeshPro scoreLabel;
    public int totalScore = 0;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        _gameObjects = new Queue<GameObject>();
        _dnaSequenceGenerator = new DnaSequenceGenerator();
        score = int.Parse(scoreLabel.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _gameObjects.Enqueue(other.gameObject);
        totalScore++;

    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Triggered");
        Debug.Log(_gameObjects.Count);
        if (_gameObjects.Count >= 2)
        {
            var base1 = _gameObjects.Dequeue().GetComponentInChildren<BaseButoonAppearance>().label.ToCharArray()[0];
            var base2 = _gameObjects.Dequeue().GetComponentInChildren<BaseButoonAppearance>().label.ToCharArray()[0];
            if (_dnaSequenceGenerator.BaseMatch(base1) == base2)
            {
                Debug.Log("CORRECT");
            }
            else
            {
                Debug.Log("WRONG");
                score -= 5;
                scoreLabel.text = score.ToString();
            }
        }

        if (score <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
            PlayerPrefs.SetInt("totalScore", totalScore/2);
        }
    }
}
