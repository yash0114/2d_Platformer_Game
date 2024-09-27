using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float StartingHealth; // the starting health when game will start
    public float currentHealth { get; private set; }
    // this will ensure that nobody can change Currenthealth value from any other script 
    // and it can only be changed from ' TakeDamage ' function
    private Animator anim;
    private bool dead;

    // Audio for hurt
    [SerializeField] private AudioSource hurtsoundEffect;

    // Audio for death
    [SerializeField] private AudioSource deathsoundEffect;
    private void Awake()
    {
        currentHealth = StartingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, StartingHealth);  // we never want to have more health then the health we have in current game
        
        if(currentHealth > 0 )
        {
            hurtsoundEffect.Play();
            anim.SetTrigger("hurt");
        }
        else
        {
            if(!dead)   // dead will only execute the code if dead variable is false
            {
                deathsoundEffect.Play();
                anim.SetTrigger("die");
                GetComponent<Player>().enabled = false;  
                dead = true;  // after the code is executed set the dead variable to be true
            }  
        }
    }
    public void addHealth(float _value)  // to add health using health potion
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, StartingHealth);   
    }

}
