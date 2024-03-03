using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    Collider2D[] objectsInRadius;
    [SerializeField] LayerMask aoe;
    [SerializeField] bool charge = false;
    [SerializeField] bool batteryFound = false;

    public void addCharge(){
        charge = true;
    }

    public void removeCharge(){
        charge = false;
    }
    public bool hasCharge(){
        return charge;
    }
    void Update()
    {
        objectsInRadius = Physics2D.OverlapCircleAll(transform.position, 0.5f, aoe);
        
         foreach(Collider2D obj in objectsInRadius){
            
            if(obj.tag == "Battery"){
                //Debug.Log("Found a battery");
                addCharge();
                batteryFound = true;
            }
        if(!batteryFound){
            removeCharge();
        }
        batteryFound = false;
        }
    }
}
