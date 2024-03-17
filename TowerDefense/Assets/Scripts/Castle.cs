using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public float totalHealth = 100f;

    private float _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        //set the current health of our castle to the max health when the game starts.
        _currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function for our castle to take damage when enemies reach it.
    public void TakeDamage(float damageTaken)
    {
        //subtracts the damage the enemy does from the castle's current health.
        _currentHealth -= damageTaken;

        if(_currentHealth <= 0)
        {
            //stops the health from going below 0
            _currentHealth = 0;
            //turns off the object when its current health reaches 0.
            gameObject.SetActive(false);
        }
    }
}
