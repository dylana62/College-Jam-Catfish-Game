using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float lanePosition = 15;
    private bool hasHitPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Drive();
    }

    void Drive()
    {
        if (!hasHitPlayer) { 
            if (gameObject.transform.position.y != lanePosition)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, lanePosition, gameObject.transform.position.z);
            }

        gameObject.transform.Translate(speed, 0, 0); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasHitPlayer = true;
        }
    }
}
