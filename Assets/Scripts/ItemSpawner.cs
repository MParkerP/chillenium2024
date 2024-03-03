using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawner : MonoBehaviour
{
    public GameObject waterBarrel;
    public GameObject glue;
    public GameObject baracade;
    public GameObject redBarrel;
    public GameObject spike;
    public GameObject battery;
    public GameObject rotator1;
    public GameObject rotator2;
    public GameObject rotator3;
    private GameObject item;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void spawnItems(int numItems)
    {
        for (int i = 0; i < numItems; i++) 
        {
            

            int number = Random.Range(0, 7);
            switch (number)
            {
                case 0:
                    item = waterBarrel; break;
                
                case 1:
                    item = glue; break;

                case 2:
                    item = baracade; break;

                case 3:
                    item = redBarrel; break;

                case 4:
                    item = spike; break;
                
                case 5:
                    item = battery; break;
                
                case 6:
                    number = Random.Range(0, 3);
                    switch (number)
                    {
                        case 0:
                            item = rotator1; break;

                        case 1:
                            item = rotator2; break;

                        case 2:
                            item = rotator3; break;
                    }
                    break;
                   


            }
            Instantiate(item, new Vector2(-4+i, 0), Quaternion.identity);
        }
    }
}
