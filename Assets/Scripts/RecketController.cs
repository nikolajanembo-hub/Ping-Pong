using UnityEngine;

public class RecketController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private void Start()
    {
        Debug.Log("Igra je pocela");
        Debug.Log(transform.name);
     
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3 (0, speed,0);      
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, speed, 0);
        }
    }
}
