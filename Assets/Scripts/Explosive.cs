using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    Collider2D[] objectsInRadius;
    [SerializeField] LayerMask aoe;
    //[SerializeField] bool showRadius = false;
    [SerializeField] private float blastRadius;
    [SerializeField] private int explosionDamage;

    public void explode()
    {
        StartCoroutine(explodeWithDelay());
    }
    public AudioClip explosion;
    IEnumerator explodeWithDelay(){
        yield return new WaitForSeconds(0.15f);
        objectsInRadius = Physics2D.OverlapCircleAll(transform.position, blastRadius, aoe);
        //Debug.Log(transform.position); 
        SoundEffects Effects = GameObject.Find("SoundEffects").GetComponent<SoundEffects>();
        if (Effects != null ) { Effects.PlaySoundEffect(explosion); }
        foreach (Collider2D obj in objectsInRadius){
           // Debug.Log(obj.ToString());
            if(obj.GetComponent<HealthBar>() && obj.gameObject != this.gameObject){
                Debug.Log("ObjectExlploded");
                obj.GetComponent<HealthBar>().takeDamage(explosionDamage);
            }
        }
        Destroy(gameObject);

       // Debug.Log("Exploded.");
       //Debug.Log(objectsInRadius + "Should have been damaged");
    }
}
