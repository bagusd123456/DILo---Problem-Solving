using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    Spawner spawner;
    private Rigidbody2D rb;
    private Vector2 direction;

    private float _h;
    private float _v;
    [SerializeField]
    private float timeClone;

    public GameObject spawnerGameObject;
    [SerializeField]
    public float force = 15;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //direction = new Vector2(15f, 5f);
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        if(spawnerGameObject == null)
        {

        }
        else
        {
            spawner = spawnerGameObject.GetComponent<Spawner>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //gameObject.transform.position = worldPosition;
        transform.Translate(direction * force, Space.World);
    }

    public void Move(float _h, float _v)
    {
        direction = new Vector2(_h, _v);
    }

    public void MoveMouse(float _h, float _v)
    {
        gameObject.transform.position = new Vector3(_h, _v, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var contactPoint = collision.contacts[0].point;
        Vector2 ballLocation = transform.position;
        var inNormal = (ballLocation - contactPoint).normalized;
        direction = Vector2.Reflect(direction, inNormal);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CubePrefab"))
        {
            SkorController.score++;
            Destroy(collision.gameObject);
            timeClone = Time.time + 2f;
            if (timeClone >= Time.time)
            {
                spawner.SpawnBoxRandom();
                timeClone = 0f;
            }
        }
    }
}
