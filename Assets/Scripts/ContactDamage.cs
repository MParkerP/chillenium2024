using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    //any tag included as a string in this array will be damaged
    [SerializeField] private string[] damageTags;
    [SerializeField] private int contactDamage;
    [SerializeField] private int damageTicDelay = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (damageTags.Contains<string>(collision.gameObject.tag))
        {
            GameObject targetObject = collision.gameObject;
            HealthBar targetHealthbar = targetObject.GetComponent<HealthBar>();
            if (targetHealthbar != null)
            {
                StartCoroutine(DamageTics(targetHealthbar));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StopAllCoroutines();
    }

    IEnumerator DamageTics(HealthBar targetHealthbar)
    {
        while(true)
        {
            targetHealthbar.takeDamage(contactDamage);
            yield return new WaitForSeconds(damageTicDelay);
        }
    }
}
