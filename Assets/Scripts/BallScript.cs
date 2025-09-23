using System.Collections;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int direction = 1;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text winnerText;
    [SerializeField] private float angle = 0.1f;

    private int playerScore1 = 0;
    private int playerScore2 = 0;
    private float startingSpeed = 0f;
    private bool gameStarted = false;
    private float startingAngle = 0f;
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
            int randomNumber2 = Random.Range(1, 3);

            gameStarted = true;

            if (randomNumber == 1)
            {
                direction = -1;
            }
            if (randomNumber == 2)
            {
                direction = 1;
        
            }
            if (randomNumber2 == 2) 
            {
                angle = -angle;
            }
        }

        if(gameStarted)
        { 
            gameObject.transform.position += new Vector3(speed * direction, angle * direction, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        direction = -direction;
        angle =- angle;
        
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
            direction = -direction;
        }

        if (collision.CompareTag("Bottom Border"))
        {
            direction = -direction;
        }

        if (playerScore1 == 3)
        {
            winnerText.fontSize = 50;
            winnerText.text = "PLAYER 1 VICTORY";
            gameStarted = true;
            speed = 0;
            angle = 0;
            StartCoroutine(RestartGame());
        }

        if (playerScore2 == 3)
        {
            winnerText.fontSize = 50;
            winnerText.text = "PLAYER 2 VICTORY";
            gameStarted = true;
            speed = 0;
            angle = 0;
            StartCoroutine(RestartGame());
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
