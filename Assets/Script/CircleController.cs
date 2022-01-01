using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    public float force = 15;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(new Vector2(15f, 5f) * Time.deltaTime * force);
    }
}
