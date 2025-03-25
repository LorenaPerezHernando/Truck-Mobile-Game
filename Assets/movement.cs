using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    void Start()
    {
        rb.AddForce(-Vector3.right * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
