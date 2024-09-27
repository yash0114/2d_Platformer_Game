using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementdistance;
    private float leftedge;
    private float rightedge;
    private bool movingleft;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private void Awake()
    {
        leftedge = transform.position.x - movementdistance;
        rightedge = transform.position.x + movementdistance;
    }
    private void Update()
    {
        if (movingleft)
        {
            if (transform.position.x > leftedge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingleft = false;
            }
        }
        else
        {
            if (transform.position.x < rightedge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingleft = true;
            }
        }
    }
}
