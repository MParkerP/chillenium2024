using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    private GameObject playerTarget;

    private Rigidbody2D enemyRb;
    [SerializeField] private float moveSpeed;

    private GameObject targetOpening = null;
    bool foundOpening = false;

    private Ray2D enemyToPlayerRay;

    private void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //chasePlayer();


        //raycasting
        enemyToPlayerRay = new Ray2D(transform.position, getDirectionToPlayer());
        Debug.DrawRay(enemyToPlayerRay.origin, enemyToPlayerRay.direction*20);
        Debug.DrawRay(transform.position, enemyRb.velocity.normalized *20);
        LayerMask playerLayer = LayerMask.GetMask("Player");
        LayerMask wallLayer = LayerMask.GetMask("Wall");
        LayerMask rayLayerMask = playerLayer | wallLayer;
        RaycastHit2D hitData = Physics2D.Raycast(transform.position, getDirectionToPlayer(), Mathf.Infinity,rayLayerMask);
        if (hitData.collider.tag == "Player")
        {

            chasePlayer();
        }
        else
        {
            getInside();
        }
    }

    void getInside()
    {

        if (!foundOpening)
        {
            GameObject[] openings = GameObject.FindGameObjectsWithTag("Opening");
            targetOpening = getClosestOpening(openings);
            foundOpening = true;
        }

        if (foundOpening && targetOpening!=null)
        {
            float targetX = targetOpening.transform.position.x;
            float targetY = targetOpening.transform.position.y;
            enemyRb.velocity = new Vector2(targetX - transform.position.x, targetY - transform.position.y).normalized * moveSpeed;
        }
        
    }

    GameObject getClosestOpening(GameObject[] openings)
    {
        GameObject closest = null;
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject opening in openings)
        {
            float distanceToOpening = distance(this.gameObject, opening);
            if (distanceToOpening < shortestDistance)
            {
                shortestDistance = distanceToOpening;
                closest = opening;
            }
        }
        return closest;
    }

    void chasePlayer()
    {
        enemyRb.velocity = getDirectionToPlayer() * moveSpeed;
    }

    Vector2 getDirectionToPlayer()
    {
        float enemyX = transform.position.x;
        float enemyY = transform.position.y;
        Vector2 newDirection = new Vector2(enemyX,enemyY);

        if (playerTarget != null)
        {
            float playerX = playerTarget.transform.position.x;
            float playerY = playerTarget.transform.position.y;


            newDirection = new Vector2(playerX - enemyX, playerY - enemyY).normalized;
        }

        return newDirection;
    }

    float distance(GameObject first, GameObject second)
    {
        float firstX = first.transform.position.x;
        float firstY = first.transform.position.y;

        float secondX = second.transform.position.x;
        float secondY = second.transform.position.y;

        return Mathf.Sqrt((firstX-secondX)*(firstX-secondX)+(firstY-secondY)*(firstY-secondY));
    }



}
