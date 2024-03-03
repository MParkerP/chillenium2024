using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sticky : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
       

    // Update is called once per frame
    void Update()
    {
   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (!collision.gameObject.CompareTag("Player")&&collision.gameObject.GetComponent<sticky>()==null)
        {
          
                gameObject.AddComponent<RelativeJoint2D>();
                RelativeJoint2D []joints = gameObject.GetComponents<RelativeJoint2D>();
                var joint = joints[joints.Length-1];
                joint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
                joint.breakForce = 1000;
                joint.breakTorque = 500;
            
        }
    }

   public void checkConnection(GameObject otherObject)
    {
        RelativeJoint2D[] joints = gameObject.GetComponents<RelativeJoint2D>();
        foreach (RelativeJoint2D joint in joints){
            if (joint.connectedBody == otherObject.GetComponent<Rigidbody2D>() )
            {
                Destroy(joint);
            };
        }
    }
}
