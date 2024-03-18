using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Castle : MonoBehaviour
{
    public float totalHealth = 100f;
    [HideInInspector]
    public float _currentHealth;

    public Slider healthSlider;

    public Transform[] attackPoints;

    // Start is called before the first frame update
    void Start()
    {
        //set the current health of our castle to the max health when the game starts.
        _currentHealth = totalHealth;

        healthSlider.maxValue = totalHealth;
        healthSlider.value = _currentHealth;
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

        healthSlider.value = _currentHealth;
    }
}
