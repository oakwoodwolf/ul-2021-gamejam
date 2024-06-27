using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int highScore = 0;
    public static int health = 3;
    public TMP_Text score;
    public TMP_Text scoreH;
    public TMP_Text healthValue;
    public Object Player;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
    }
    private void Awake()
    {
        if (scoreValue >= highScore) highScore = scoreValue;
        scoreValue = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        health = PlayerController.PlayerHealth / 2;
        score.text = "Score: " + scoreValue;
        healthValue.text = ": " + health;
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
