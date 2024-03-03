using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spillWater : MonoBehaviour
{
    public GameObject puddle;
    Transform puddleTransform;
    // Start is called before the first frame update
    public void generatePuddle(){
        //Vector3 puddleSpawn = transform.position + new Vector3(2.5f,0,0);
        puddle = Instantiate(puddle,transform.position, Quaternion.identity);
        puddleTransform = puddle.GetComponent<Transform>();
       // puddleTransform.rotation = transform.rotation;
        Destroy(gameObject);
    }

}
