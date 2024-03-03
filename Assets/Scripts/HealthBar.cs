using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    public UnityEvent handleDeath;
    public Image healthBar;
    public TMP_Text healthText;
    public bool displayHealthBar = false;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        //setHealth(100);
    }
    public void setHealth(int startingHealth){
        health = startingHealth;
        maxHealth = startingHealth;
        adjustHealthBarUI();
    }

    public void addMaxHealth(int healthToAdd){
        health += healthToAdd;
        maxHealth += healthToAdd;
        Debug.Log("Added " + healthToAdd + " health");
        adjustHealthBarUI();
        printCurrentHealth();
    }

    public void removeMaxHealth(int healthToRemove){
        maxHealth -= healthToRemove;
        if(health > maxHealth){
            health = maxHealth;
        }
        if(maxHealth <= 0 && !isDead){
            handleDeath?.Invoke();
        }

        Debug.Log("Max health Removed");
        adjustHealthBarUI();
        printCurrentHealth();
    }

    public void heal(int healing){
        if(healing + health >= maxHealth){
            health = maxHealth;
        }else{
            health += healing;
        }
        
        
        Debug.Log("Healing recieved");
        adjustHealthBarUI();
        printCurrentHealth();
    }

    public void death()
    {
        isDead = true;
        handleDeath?.Invoke();
    }

    public void takeDamage(int damageTaken){
        if(!isDead)
        {
            health -= damageTaken;
        }
        if(health <= 0 && !isDead){
            Debug.Log("Died");
            death();
        }
        Debug.Log("Damage taken");
        adjustHealthBarUI();
        printCurrentHealth();
        StartCoroutine(flashRed());
        
    }

    void printCurrentHealth(){
        Debug.Log("Current Health: " + health + "\n Max Health: " + maxHealth + "\n" + health + "/" + maxHealth);
    }


    void adjustHealthBarUI(){
        if(displayHealthBar){   
            healthBar.fillAmount = health / maxHealth;
            //healthText.text = health + "/" + maxHealth;
        }
    }

    IEnumerator flashRed(){
        SpriteRenderer objectSp = GetComponent<SpriteRenderer>();
        objectSp.color = new Color(255,0,0);
        yield return new WaitForSeconds(0.1f);
        objectSp.color = new Color(255,255,255);
    }

}
