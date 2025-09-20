using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int direction = 1;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text WinnerText;
    private int playerScore1 = 0;
    private int playerScore2 = 0;
   
    private bool gameStarted = false;
    private Vector3 startPos;


    private void Start()
    {
        scoreText.text = playerScore1 + ":" + playerScore2;
        scoreText.fontSize = 45; 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameStarted == false)
        {
            int randomNumber = Random.Range(1, 3);
            Debug.Log(randomNumber);
            gameStarted = true;
            if (randomNumber == 1)
            {
                direction = -1;
            }
            if (randomNumber == 2)
            {
                direction = 1;
        
            }
            
        }
        if(gameStarted)
        { 
            gameObject.transform.position += new Vector3(speed * direction, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        direction = -direction;
        if (collision.CompareTag("Right Goal"))
        {
            Debug.Log("Player 1 Point!");
            transform.position = startPos;
            gameStarted = false;
            playerScore1 += 1;
            Debug.Log("Player 1 Score "+ playerScore1);
            scoreText.text = playerScore1 + ":" + playerScore2;

        }
        if (collision.CompareTag("Left Goal"))
        {
            Debug.Log("Player 2 Point!");
            transform.position = startPos;
            gameStarted = false;
            playerScore2 += 1;
            Debug.Log("Player 2 Score " + playerScore2);
            scoreText.text = playerScore1 + ":" + playerScore2;
        }
        if (playerScore1 == 3)
        {

        }
    }
    
}
