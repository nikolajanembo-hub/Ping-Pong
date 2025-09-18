using UnityEngine;

public class RocketController1 : MonoBehaviour
{
    [SerializeField] private float speed1 = 5f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, speed1, 0);
        }
    }
}
