using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class pickUpableV2 : MonoBehaviour
{
    // Start is called before the first frame update
    Transform objectTr;
    Transform playerTr;
    moveScript player;
    Rigidbody2D objectCo;
    bool pickedUp;
    LayerMask defaultLayer;
    LayerMask heldLayer;

    void Start()
    {
        objectTr = GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<moveScript>();
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
        objectCo = GetComponent<Rigidbody2D>();
        pickedUp = false;
        defaultLayer = gameObject.layer;
        heldLayer = LayerMask.NameToLayer("HeldObjects");
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    private void held()
    {
        transform.SetParent(playerTr);
    }


    
    public void togglePickUp()
    {
        if (!pickedUp)
        {
            transform.SetParent(playerTr);
            objectCo.bodyType = RigidbodyType2D.Kinematic;
            gameObject.layer = heldLayer;
            pickedUp = true;
            //objectCo.enabled = false;
        }
        else
        {
            transform.SetParent(null);
            objectCo.bodyType = RigidbodyType2D.Dynamic;
            pickedUp = false;
            gameObject.layer = defaultLayer;

            //objectCo.enabled = true;
        }
    }

   
}
