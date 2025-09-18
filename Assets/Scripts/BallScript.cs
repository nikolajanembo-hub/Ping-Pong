using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int direction = 1;
    private bool gameStarted = false;
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
        Debug.Log(collision.gameObject.name);
        // if ( direction == 1)
        direction = -direction;
    }
}
