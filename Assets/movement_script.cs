using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class movement_script : MonoBehaviour
{

    Vector3 mousePosition;
    public float movespeed = 0.1f;
    Rigidbody2D rb;
    Vector2 position = new Vector2 (0, 0);
    private bool clicked = false;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
            GetComponent<Rigidbody2D>().isKinematic = false;
        }

        if (!clicked)
        {
           if(general_script.alive == true && spawn_script.pausedd == false)
            {
                float mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                mousePosition = new Vector2(mouseposition, 3);
 //               mousePosition = Input.mousePosition.x;
    //            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                position = Vector2.Lerp(transform.position, mousePosition, movespeed);
                rb.MovePosition(position);
            }
        }


        if (!clicked) 
        {
            if (transform.position.x <= -2.6)
            {
                gameObject.transform.position = new Vector2(-2.5f, 3);
            }
            if (transform.position.x >= 2.8)
            {
                gameObject.transform.position = new Vector2(2.7f, 3);
            }
        }
    }

}
