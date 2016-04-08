/*
**  Author: Jack Vine
**
**  Hold stat-related variables and functions for a character.
*/

using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour
{
    public int health = 100, maxHealth = 100;

    public int oxygen = 100, maxOxygen = 100;

    public int food = 50, maxFood = 50;

    //Adds the specified amount of health, up to the max
    public void AddHealth(int amount)
    {
        health += amount;

        if (health > maxHealth)
            health = maxHealth;
    }

    //Adds the specified amount of oxygen, up to the max
    public void AddOxygen(int amount)
    {
        oxygen += amount;

        if (oxygen > maxOxygen)
            oxygen = maxOxygen;
    }

    //Adds the specified amount of food, up to the max
    public void AddFood(int amount)
    {
        food += amount;

        if (food > maxFood)
            food = maxFood;
    }

}
