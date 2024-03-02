using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class pickUpable : MonoBehaviour
{
    // Start is called before the first frame update
    Transform objectTr;
    Transform playerTr;
    moveScript player;
    Collider2D objectCo;
    bool pickedUp;
    LayerMask defaultLayer;
    LayerMask heldLayer;


    void Start()
    {
        objectTr = GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<moveScript>();
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
        objectCo = GetComponent<Collider2D>();
        pickedUp = false;

        defaultLayer = gameObject.layer;
        heldLayer = LayerMask.NameToLayer("HeldObjects");
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            held();
        }  
    }
    private void held()
    {
        switch (player.facing)
        {
            case (1):
                objectTr.position = new Vector2(playerTr.position.x, playerTr.position.y + 0.5f);
               
                break;

            case (3):
                objectTr.position = new Vector2(playerTr.position.x, playerTr.position.y - 0.5f);

                break;

            case (2):
                objectTr.position = new Vector2(playerTr.position.x + 0.5f, playerTr.position.y);

                break;

            case (0):
                objectTr.position = new Vector2(playerTr.position.x - 0.5f, playerTr.position.y);
                break;



            case (0.5f):
                objectTr.position = new Vector2(playerTr.position.x - 0.5f, playerTr.position.y + 0.5f);
                break;

            case (1.5f):
                objectTr.position = new Vector2(playerTr.position.x + 0.5f, playerTr.position.y + 0.5f);

                break;

            case (3.5f):
                objectTr.position = new Vector2(playerTr.position.x - 0.5f, playerTr.position.y - 0.5f);

                break;

            case (2.5f):
                objectTr.position = new Vector2(playerTr.position.x + 0.5f, playerTr.position.y - 0.5f);

                break;
        }
        objectTr.rotation = playerTr.rotation;
    }


    
    public void togglePickUp()
    {
        if (!pickedUp)
        {
            gameObject.layer = heldLayer;
            pickedUp = true;
            objectCo.enabled = false;
        }
        else
        {
            gameObject.layer = defaultLayer;
            pickedUp = false;
            objectCo.enabled = true;
        }
    }

   
}
