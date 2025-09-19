using UnityEngine;

public class RocketController1 : MonoBehaviour
{
    [SerializeField] private float speed1 = 5f;
    private bool canMoveUp1 = true;
    private bool canMoveDown1 = true;
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && canMoveUp1 == true)
        {
            transform.position += new Vector3(0, speed1, 0);
        }
        if (Input.GetKey(KeyCode.S) && canMoveDown1 == true)
        {
            transform.position -= new Vector3(0, speed1, 0);
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
