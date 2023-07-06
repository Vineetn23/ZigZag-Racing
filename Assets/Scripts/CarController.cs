using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject pickUpEffect;
    public float moveSpeed;
    bool movingLeft = true;
    bool firstInput = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            CheckInput();
        }

        if(transform.position.y <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void CheckInput()
    {
        if (firstInput)
        {
            firstInput = false;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if (movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        GameManager.instance.TapScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Star")
        {
            GameManager.instance.IncrementScore();
            Instantiate(pickUpEffect, other.transform.position, pickUpEffect.transform.rotation);
            other.gameObject.SetActive(false);
        }
    }
}
