using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    Rigidbody2D playerRb;
    Transform playerTr;
    float horizontalInput;
    Collider2D[] pickUpArea;
    float verticalInput;
    [SerializeField] public LayerMask layer;
    [SerializeField]GameObject item;
    [SerializeField] bool holding;
    [SerializeField] public float speed;
    [SerializeField] public bool pickUp;
    [SerializeField] public bool interact;
    [SerializeField] string pickUpKey;
    [SerializeField] string interactKey;
    [SerializeField] string useKey;
    [SerializeField] public float facing;
    [SerializeField] public float radius;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerTr = GetComponent<Transform>();
        speed = 10;
        interact = false;
        pickUp = false;
        holding = false;
        pickUpKey = "l";
        interactKey = "k";
        
        radius = 3;
        
        

    }

    // Update is called once per frame
    void Update()
    {
        move();
        rotate();
       
        if (Input.GetKeyDown(pickUpKey))
        {
            pickUpHandler();
        }
        interactHandler();
        pickUpArea = Physics2D.OverlapCircleAll(new Vector2(playerTr.position.x, playerTr.position.y), radius, layer);
    }

    private void move()
    {
       horizontalInput = Input.GetAxisRaw("Horizontal");
       verticalInput = Input.GetAxisRaw("Vertical");
       playerRb.velocity = new Vector2(horizontalInput*speed, verticalInput*speed);
           
    }

    private void rotate()
    {
        switch (verticalInput, horizontalInput)
        {
            case (1, 0):
                transform.rotation = Quaternion.Euler(0, 0, 270); //moving up
                facing = 1;
                break;

            case (-1, 0):
                transform.rotation = Quaternion.Euler(0, 0, 90); //moving down
                facing = 3;
                break;

            case (0, 1):
                transform.rotation = Quaternion.Euler(0, 0, 180); //moving right
                facing = 2;
                break;

            case (0, -1):
                transform.rotation = Quaternion.Euler(0, 0, 0); //moving left
                facing = 0;
                break;



            case (1, -1):
                transform.rotation = Quaternion.Euler(0, 0, 315); //moving up-left
                facing = 0.5f;
                break;

            case (1, 1):
                transform.rotation = Quaternion.Euler(0, 0, 225); //moving up-right
                facing = 1.5f;
                break;

            case (-1, -1):
                transform.rotation = Quaternion.Euler(0, 0, 45); //moving down-left
                facing = 3.5f;
                break;

            case (-1, 1):
                transform.rotation = Quaternion.Euler(0, 0, 135); //moving down-right
                facing = 2.5f;
                break;
        }
    }

    private void pickUpHandler()
    {
        if (holding == false)
        {
            
            float shortest = Mathf.Infinity;
            foreach (Collider2D collider in pickUpArea)
            {
               float temp = distance(collider.gameObject, gameObject);
               if(temp < shortest)
                {
                    shortest = temp;
                    item = collider.gameObject;
                    
                }
               
            }
            if(item != null&& item.GetComponent<pickUpable>() != null) 
            { 
                item.GetComponent<pickUpable>().togglePickUp();
                holding = true;
            }
            
        }
        else if(holding == true) 
        {
            item.GetComponent<pickUpable>().togglePickUp();
            item = null;
            holding = false;
        }
    }

    private void interactHandler()
    {
        if (Input.GetKeyDown(interactKey))
        {
            float shortest = Mathf.Infinity;
            foreach (Collider2D collider in pickUpArea)
            {
                float temp = distance(collider.gameObject, gameObject);
                if (temp < shortest)
                {
                    shortest = temp;
                    item = collider.gameObject;
                }

            }
            if (item != null&&item.GetComponent<interactable>()!=null) { item.GetComponent<interactable>().interact(); }
        }
    }

  

    float distance(GameObject first, GameObject second)
    {
        float firstX = first.transform.position.x;
        float firstY = first.transform.position.y;

        float secondX = second.transform.position.x;
        float secondY = second.transform.position.y;

        return Mathf.Sqrt((firstX - secondX) * (firstX - secondX) + (firstY - secondY) * (firstY - secondY));
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere( transform.position, radius);
    }

    

   
}
