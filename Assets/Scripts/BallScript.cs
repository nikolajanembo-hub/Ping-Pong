using System.Collections;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text winnerText;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float angle = 0.1f;
    [SerializeField] private int winnerScore = 3;

    private int direction = 1;
    private int directionY = -1;
    private int playerScore1 = 0;
    private int playerScore2 = 0;
    private float startingSpeed = 0f;
    private float startingAngle = 0f;
    private bool gameStarted = false;
    private Vector3 startPos; 

    private void Start()
    {
        scoreText.text = playerScore1 + ":" + playerScore2;
        scoreText.fontSize = 45;
        startingSpeed = speed;
        startingAngle = angle;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameStarted == false)
        {
            int randomNumber = Random.Range(1, 3);

            gameStarted = true;

            if (randomNumber == 1)
            {
                direction = -1;
                angle = -angle;
            }
            else
            {
                direction = 1;
                angle = -angle;
            }
        }

        if(gameStarted)
        { 
            gameObject.transform.position += new Vector3(speed * direction, angle * directionY, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Right Goal"))
        {
            transform.position = startPos;
            gameStarted = false;
            playerScore1 += 1;
            scoreText.text = playerScore1 + ":" + playerScore2;
        }

        if (collision.CompareTag("Left Goal"))
        {
            transform.position = startPos;
            gameStarted = false;
            playerScore2 += 1;
            scoreText.text = playerScore1 + ":" + playerScore2;
        }

        if (collision.CompareTag("Top Border"))
        {
            directionY = -directionY;
        }

        if (collision.CompareTag("Bottom Border"))
        {
            directionY = -directionY;
        }

        if (playerScore1 == winnerScore)
        {
            winnerText.fontSize = 50;
            winnerText.text = "PLAYER 1 VICTORY";
            gameStarted = true;
            speed = 0;
            angle = 0;
            StartCoroutine(RestartGame());
        }

        if (playerScore2 == winnerScore)
        {
            winnerText.fontSize = 50;
            winnerText.text = "PLAYER 2 VICTORY";
            gameStarted = true;
            speed = 0;
            angle = 0;
            StartCoroutine(RestartGame());
        }

        if(collision.name == "RecketPlayer1"){
            direction = -direction;
        }

        if(collision.name == "RecketPlayer2"){
            direction = -direction;
        }
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3);

        playerScore1 = 0;
        playerScore2 = 0;
        gameStarted = false;
        winnerText.text = "";
        scoreText.text = playerScore1 + ":" + playerScore2;
        speed = startingSpeed;
        angle = startingAngle;
    }
}
