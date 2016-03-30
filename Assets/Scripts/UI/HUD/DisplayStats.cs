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

    public Slider oxygenSlider;
    public Text oxygenText;

    public Slider foodSlider;
    public Text foodText;

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
        oxygenSlider.value = (float)stats.oxygen / stats.maxOxygen;
        oxygenText.text = ((float)stats.oxygen / stats.maxOxygen).ToString("P");

        foodSlider.value = (float)stats.food / stats.maxFood;
        foodText.text = ((float)stats.food / stats.maxFood).ToString("P");
    }
}
