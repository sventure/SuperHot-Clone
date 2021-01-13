using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    public virtual void handleInput(enemyMovement thisObject) { }

    public virtual void enemyMove(enemyMovement thisObject) { }

}

public class WalkingState : EnemyState
{
    public override void handleInput(enemyMovement thisObject)
    {
        if (thisObject.enemyAlert == true)
        {
            thisObject.currentState = new AlertState();
        }
    }

    public override void enemyMove(enemyMovement thisObject)
    {
        thisObject.transform.position += thisObject.transform.forward * thisObject.enemySpeed * Time.deltaTime;
    }
}
public class AlertState : EnemyState
{
    public override void handleInput(enemyMovement thisObject)
    {
        if (thisObject.enemyAlert == false)
        {
            thisObject.currentState = new WalkingState();
            thisObject.transform.Rotate(Vector3.up, Random.Range(0f, 360f));
        }
    }

    public override void enemyMove(enemyMovement thisObject)
    {
        thisObject.transform.LookAt(thisObject.Player);
        thisObject.transform.position += thisObject.transform.forward * thisObject.enemySpeed * Time.deltaTime;
    }

  /*  public void shootPlayer(enemyMovement thisObject)
    {
        if (Time.time > thisObject.nextFire)
        {
            thisObject.nextFire = Time.time + thisObject.fireRate;
            Instantiate(thisObject.bullet, thisObject.bulletSpawn.position, thisObject.bulletSpawn.rotation);
        }
    } */
}



public class enemyMovement : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;

    public float fireRate = 1.5f;
    public float nextFire = 0f;

    public Transform Player;
    public float enemySpeed = 3f;

    public EnemyState currentState;
    public bool enemyAlert = false;

    // Start is called before the first frame update
    void Start()
    {
        currentState = new WalkingState();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distFromPlayer = Vector3.Distance(transform.position, Player.position);
        if(distFromPlayer <= 25f)
        {
            //transform.LookAt(Player);
            //transform.position += transform.forward * enemySpeed * Time.deltaTime;
            enemyAlert = true;
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            }
        }
        else
        {            
            enemyAlert = false;
            
        }

        currentState.handleInput(this);
        currentState.enemyMove(this);
        //Debug.Log(currentState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 100, transform.rotation.z);
        }
    }
}
