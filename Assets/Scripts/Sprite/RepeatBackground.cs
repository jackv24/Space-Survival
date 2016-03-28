using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class RepeatBackground : MonoBehaviour
{
    public float screenCheckSeconds = 1f;

    private BoxCollider2D col;
    private Camera cam;

    [HideInInspector]
    public bool left = false, right = false, up = false, down = false;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        cam = Camera.main;

        StartCoroutine("CheckIfOnScreen");
    }

    IEnumerator CheckIfOnScreen()
    {
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Vector2 max;
        Vector2 min;

        while (true)
        {
            max = new Vector2(cam.transform.position.x + width, cam.transform.position.y + height);
            min = new Vector2(cam.transform.position.x - width, cam.transform.position.y - height);

            if (col.bounds.max.x >= max.x ||
                col.bounds.max.y >= max.y ||
                col.bounds.min.x <= min.x ||
                col.bounds.min.y <= min.y)
            {
                //gameObject.SetActive(false);
            }
            else
            {
                if (col.bounds.min.x <= max.x && !right)
                {
                    //right side
                    Vector3 pos = new Vector3(transform.position.x + col.size.x * 2, transform.position.y, transform.position.z);

                    GameObject obj = (GameObject)Instantiate(gameObject, pos, transform.rotation);

                    right = true;
                    obj.GetComponent<RepeatBackground>().left = true;
                }
                else if (col.bounds.max.x >= min.x && !left)
                {
                    //left side
                    Vector3 pos = new Vector3(transform.position.x - col.size.x * 2, transform.position.y, transform.position.z);

                    GameObject obj = (GameObject)Instantiate(gameObject, pos, transform.rotation);

                    left = true;
                    obj.GetComponent<RepeatBackground>().right = true;
                }

                if (col.bounds.min.y <= max.y)
                {
                    //top side
                }
                else if (col.bounds.max.y >= min.y)
                {
                    //bottom side
                }
            }

            yield return new WaitForSeconds(screenCheckSeconds);
        }
    }
}
