using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class general_script : MonoBehaviour
{

    float add01;
    float take01;
    public double timeLeft = 3.0;
    public Text countdown;
    int a = 2;
    float thing;
    static public bool alive = true; 

    // Start is called before the first frame update
    void Start()
    {
        add01 = gameObject.transform.position.x + 0.00001f;
        take01 = gameObject.transform.position.x - 0.001f;
    }

   // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -50)
        {
            gameObject.transform.position = new Vector2(0, 0);
        }
        if (general_script.alive == false)
        {
            Destroy(countdown);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (general_script.alive == true && spawn_script.pausedd == false)
        {
            if (gameObject.tag == "death" && collision.gameObject.tag != "tarantula" && collision.gameObject.tag != "frog" && collision.gameObject.tag != "p")
            {
                timeLeft -= Time.deltaTime;
                thing = (float)timeLeft;
                timeLeft = Mathf.Round(thing * Mathf.Pow(10, a)) / Mathf.Pow(10, a);
                countdown.text = ("Life = " + (timeLeft).ToString()) + ("s");
                if (timeLeft < 0)
                {
                    alive = false;
                    Debug.Log("you ded :(");
                }
            }

            if (collision.gameObject.tag == "edge")
            {
                if (transform.position.x > 0)
                {
                    gameObject.transform.position = new Vector2(take01, transform.position.y);
                    Debug.Log("wasedrfgth");
                }
                if (transform.position.x < 0)
                {
                    gameObject.transform.position = new Vector2(add01, transform.position.y);
                }
            }
        }
  
    }

}
