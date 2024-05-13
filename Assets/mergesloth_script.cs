using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mergesloth_script : MonoBehaviour
{
    int ID;
    public GameObject Mergedobject;
    private bool hascollided = false;
    public GameObject Capybara;


    // Start is called before the first frame update
    void Start()
    {
        ID = GetInstanceID();
    }

    void Update()
    {
        if (transform.position.y <= -4)
        {
            gameObject.transform.position = new Vector2(transform.position.x, -3);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("sloth"))
        {
            if (!hascollided)
            {
                if (ID < collision.gameObject.GetComponent<mergesloth_script>().ID) { return; }
                Debug.Log($"merge{gameObject.name}");
                GameObject o = Instantiate(Mergedobject, transform.position, Quaternion.identity) as GameObject;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                hascollided = true;
                GameObject a = Instantiate(Capybara, Capybara.transform.position, Quaternion.identity) as GameObject;
                Destroy(spawn_script.questionca);
                spawn_script.score += 75;
            }
        }
    }
}
