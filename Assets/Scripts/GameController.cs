using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject ball;
    public Transform player;
    private Destroyer destroyerScript;
    private BallMover ballMoverScript;

    [Header("UI Objects")]
    public Text scoreText;
    public GameObject playerWinText;
    public GameObject restartTextObject;

    private int score = 0;
    private bool playerWin = false;
    private bool restart = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void AddToScore(int scoreValueToAdd)
    {
        score += scoreValueToAdd;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    public void BallCreator()
    {
        Instantiate(ball, transform.position, transform.rotation);
    }

    public void PlayerWin()
    {
        playerWin = true;
        playerWinText.SetActive(true);
        restart = true;
        restartTextObject.SetActive(true);
    }
}
