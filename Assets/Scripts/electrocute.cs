using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electrocute : MonoBehaviour
{
    [SerializeField] LayerMask aoe;
    Collider2D[] objectsInRadius;
    bool isFlashing = false;

    public Color yellow = new Color(.240f,.233f,.38f,.9f);
    public Color blue = new Color(.59f,.163f,.172f,.9f); 
    // Update is called once per frame
    void Update()
    {
        objectsInRadius = Physics2D.OverlapBoxAll(transform.position, new Vector3(3.85f, 1, 0), 0, aoe);
        foreach(Collider2D obj in objectsInRadius){
            if(obj.GetComponent<HealthBar>() && gameObject.GetComponent<Charge>().hasCharge()){
               StartCoroutine(zap(obj));
            }
        }
        if(gameObject.GetComponent<Charge>().hasCharge() && !isFlashing){
            StartCoroutine(flashYellow());
        }
    }

    IEnumerator zap(Collider2D obj){
        obj.GetComponent<HealthBar>().takeDamage(.3f);
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator flashYellow(){
        isFlashing = true;
        SpriteRenderer objectSp = GetComponent<SpriteRenderer>();
        objectSp.color = yellow;
        Debug.Log("Set Color to yellow");
        yield return new WaitForSeconds(.05f);
        objectSp.color = blue; 
        Debug.Log("Set Color to Blue");
        yield return new WaitForSeconds(0.6f);
      
        //Debug.Log("Flashing yellow");

        isFlashing = false;
    }
}
