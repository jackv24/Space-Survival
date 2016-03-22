/*
**  Author: Jack Vine
**
**  Displays stat information from the player in the HUD
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Slider healthSlider;
    public Text healthText;

    public Text oxygenText;

    private CharacterStats stats;

    void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<CharacterStats>();
    }

    void Update()
    {
        //Set health slider to health/maxHealth (cast one to float so that resulting value is a float)
        healthSlider.value = (float)stats.health / stats.maxHealth;
        healthText.text = stats.health + "/" + stats.maxHealth;

        //Display the amount of oxygen as a percentage
        oxygenText.text = ((float)stats.oxygen / stats.maxOxygen).ToString("P");
    }
}
