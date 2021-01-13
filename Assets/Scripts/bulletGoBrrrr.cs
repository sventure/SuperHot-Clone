using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGoBrrrr : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float destroyTimer = 3f;
    public Rigidbody rb;
    public scoreScript ScoreScript;

    [SerializeField] float timeInWorld;

    // Start is called before the first frame update
    void Start()
    {
        timeInWorld = 0f;
        // rb.AddRelativeForce(Vector3.forward * bulletSpeed * Time.deltaTime);
        ScoreScript = GameObject.Find("scoreText").GetComponent<scoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.forward * bulletSpeed * Time.deltaTime; 

        rb.AddRelativeForce(Vector3.up * bulletSpeed * Time.deltaTime);
        destroyCountdown();

        timeInWorld += Time.unscaledDeltaTime;
    }

    void destroyCountdown()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0f)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed Bullet");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || (collision.gameObject.tag == "Player" && timeInWorld > 0.5f))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            if (collision.gameObject.tag == "Enemy")
            {
                ScoreScript.scoreValue += 10;
            }
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
}
