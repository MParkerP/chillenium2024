using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electrocute : MonoBehaviour
{
    [SerializeField] LayerMask aoe;
    Collider2D[] objectsInRadius;

    // Update is called once per frame
    void Update()
    {
        objectsInRadius = Physics2D.OverlapBoxAll(transform.position, new Vector3(3.85f, 1, 0), 0, aoe);
        foreach(Collider2D obj in objectsInRadius){
            if(obj.GetComponent<HealthBar>() && gameObject.GetComponent<Charge>().hasCharge()){
                Debug.Log("In the hitbox");
            }
        }
    }
}
