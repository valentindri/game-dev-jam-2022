using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(-14, 5, 0);
    private Vector3 pos2 = new Vector3(18, 5, 0);
    public float speed = 1.0f;

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        if (transform.position.x >= pos2.x -1)
        {
            gameObject.transform.localScale = new Vector2(1.5f, 1.5f);
        }
        else if(transform.position.x <= pos1.x + 1)
        {
            gameObject.transform.localScale = new Vector2(-1.5f, 1.5f);
        }
        
    }
    
}