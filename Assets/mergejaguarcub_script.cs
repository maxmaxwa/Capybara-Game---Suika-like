using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mergejaguarcub_script : MonoBehaviour
{
    int ID;
    public GameObject Mergedobject;
    private bool hascollided = false;
    public GameObject coati;

    // Start is called before the first frame update
    void Start()
    {
        ID = GetInstanceID();
    }

    void Update()
    {
        if (transform.position.y <= -4.2)
        {
            gameObject.transform.position = new Vector2(transform.position.x, -3.9f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jaguar"))
        {
            if (!hascollided)
            {
                if (ID < collision.gameObject.GetComponent<mergejaguarcub_script>().ID) { return; }
                Debug.Log($"merge{gameObject.name}");
                GameObject o = Instantiate(Mergedobject, transform.position, Quaternion.identity) as GameObject;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                hascollided = true;
                GameObject gary = Instantiate(coati, coati.transform.position, Quaternion.identity) as GameObject;
                Destroy(spawn_script.questionco);
                spawn_script.score += 30;
            }
        }
    }
}
