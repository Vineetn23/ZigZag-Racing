using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject star;

    // Start is called before the first frame update
    void Start()
    {
        int randStar = Random.Range(0, 6);
        Vector3 starPos = transform.position;
        starPos.y += 0.81f;

        if(randStar < 1)
        {
            GameObject starInstance = Instantiate(star, starPos , star.transform.rotation);
            starInstance.transform.SetParent(gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.2f);
        }
    }

    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }
}
