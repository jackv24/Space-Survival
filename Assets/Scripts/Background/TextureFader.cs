/*
**  Author: Jack Vine
**
**  Fades the texture alpha from one to zero
*/

using UnityEngine;
using System.Collections;

public class TextureFader : MonoBehaviour
{
    //The speed at which it will fade (from 0-1)
    public float speed = 0.025f;

    //Should it start fading up or down?
    public bool goingUp = true;

    void Start()
    {
        StartCoroutine("FadeTexture", GetComponent<MeshRenderer>());
    }

    IEnumerator FadeTexture(MeshRenderer mesh)
    {
        Color color = mesh.material.GetColor("_TintColor");

        while (true)
        {
            if(goingUp)
                color.a = Mathf.Lerp(color.a, 1f, speed);
            else
                color.a = Mathf.Lerp(color.a, 0, speed);

            if (color.a >= 0.95f || color.a <= 0.05f)
                goingUp = !goingUp;

            mesh.material.SetColor("_TintColor", color);

            yield return null;
        }
    }
}
