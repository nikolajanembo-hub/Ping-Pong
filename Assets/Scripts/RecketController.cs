using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float speed = 5f;
    public KeyCode currentPressedDirection; 
    [SerializeField] private KeyCode directionUp;
    [SerializeField] private KeyCode directionDown;

    private bool canMoveUp1 = true;
    private bool canMoveDown1 = true;

    private void Update()
    {
        if (Input.GetKey(directionUp) && canMoveUp1 == true)
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            currentPressedDirection = directionUp;
        }
       else if (Input.GetKey(directionDown) && canMoveDown1 == true)
        {
            transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
            currentPressedDirection = directionDown;
        }
        else
        {
            currentPressedDirection = KeyCode.None;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Top Border"))
        {
            canMoveUp1 = false;
        }
        if (collision.CompareTag("Bottom Border"))
        {
            canMoveDown1 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Top Border"))
        {
            canMoveUp1 = true;
        }
        if (collision.CompareTag("Bottom Border"))
        {
            canMoveDown1 = true;
        }
    }
}
