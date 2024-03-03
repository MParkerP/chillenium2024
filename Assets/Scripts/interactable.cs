using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact(GameObject item)
    {
        Debug.Log("item interacted");
        switch(item.tag){
            case "waterBucket": item.GetComponent<spillWater>().generatePuddle(); break;
            default: break;
        }
    }
}
