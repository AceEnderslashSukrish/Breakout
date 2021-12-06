using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject ball;
    private Destroyer destroyerScript;

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
        ballCreator();
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyerScript.ballDestroyed)
        {
            Instantiate(ball, transform.position, transform.rotation);
        }
    }

    private void AddToScore(int scoreValueToAdd)
    {
        score += scoreValueToAdd;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    public void ballCreator()
    {
        Instantiate(ball, transform.position, transform.rotation);
    }

    public void PlayerWin(GameObject Player)
    {
        playerWin = true;
        playerWinText.SetActive(true);
        restart = true;
        restartTextObject.SetActive(true);
    }
}
