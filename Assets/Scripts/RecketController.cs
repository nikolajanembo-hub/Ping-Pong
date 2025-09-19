using UnityEngine;

public class RecketController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private bool canMoveUp = true;
    private bool canMoveDown = true;
    private void Start()
    {
        Debug.Log("Igra je pocela");
        Debug.Log(transform.name);
     
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && canMoveUp)
        {
            transform.position += new Vector3 (0, speed,0);      
        }
        if (Input.GetKey(KeyCode.DownArrow) && canMoveDown)
        {
            transform.position -= new Vector3(0, speed, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Top Border"))
        {
            canMoveUp = false;
        }
        if (collision.CompareTag("Bottom Border"))
        {
            canMoveDown = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Top Border"))
        {
            canMoveUp = true;
        }
        if (collision.CompareTag("Bottom Border"))
        {
            canMoveDown = true;
        }
    }
}
