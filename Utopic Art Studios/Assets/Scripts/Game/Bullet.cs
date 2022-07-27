using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;
    public float livingTime = 3f;
    void Start()
    {
        Destroy(this.gameObject, livingTime);
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = direction.normalized * speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
        /*if (horizontal < 0f || horizontal > 0f)
        {
            transform.position = new Vector2(transform.position.x + horizontal, transform.position.y);
        }
        if (vertical >= -1f || Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + vertical);
        }*/
    }
}
