/*
**  Author: Jack Vine
**
**  Fades the sprites alpha from one to zero;
*/

using UnityEngine;
using System.Collections;

public class SpriteFader : MonoBehaviour
{
    //The speed at which it will fade (from 0-1)
    public float speed = 0.025f;

    //Should it start fading up or down?
    public bool goingUp = true;

    void Start()
    {
        StartCoroutine("FadeSprite", GetComponent<SpriteRenderer>());
    }

    IEnumerator FadeSprite(SpriteRenderer sprite)
    {
        Color color = sprite.color;

        while (true)
        {
            if(goingUp)
                color.a = Mathf.Lerp(color.a, 1f, speed);
            else
                color.a = Mathf.Lerp(color.a, 0, speed);

            if (color.a >= 0.95f || color.a <= 0.05f)
                goingUp = !goingUp;

            sprite.color = color;

            yield return null;
        }
    }
}
