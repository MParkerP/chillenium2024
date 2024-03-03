using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    Transform objectTr;
    bool rotating;
    HingeJoint2D hinge;
    JointMotor2D motor;
    Rigidbody2D objectRb;
    
    // Start is called before the first frame update
    void Start()
    {
        rotating = false;
        gameObject.AddComponent<HingeJoint2D>();
        hinge = GetComponent<HingeJoint2D>();
        motor = hinge.motor;
        objectRb = GetComponent<Rigidbody2D>();
        hinge.useMotor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Charge>().hasCharge() && !rotating){
            toggleRotation(200);
        }else if(GetComponent<Charge>().hasCharge() == false && rotating){
            toggleRotation(200);
        }
        if (Input.GetKeyDown("p"))
        {
            toggleRotation(200);
        }
    }

    public void toggleRotation(float speed)
    {

        if (!rotating)
        {
            
            motor.motorSpeed = speed;
            hinge.motor = motor;
            rotating =true;
            hinge.useMotor = true;
            
        }
        else
        {
            rotating = false;
            hinge.useMotor = false;
        }
    }
}
