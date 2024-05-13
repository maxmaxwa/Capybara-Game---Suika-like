using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mergeanteater_script : MonoBehaviour
{
    int ID;
    public GameObject Mergedobject;
    private bool hascollided = false;
    public GameObject sloth;

    // Start is called before the first frame update
    void Start()
    {
        ID = GetInstanceID();
    }

    void Update()
    {
        if (transform.position.y <= -3.6)
        {
            gameObject.transform.position = new Vector2(transform.position.x, -3.2f);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("anteater"))
        {
            if (!hascollided)
            {
                if (ID < collision.gameObject.GetComponent<mergeanteater_script>().ID) { return; }
                Debug.Log($"merge{gameObject.name}");
                GameObject o = Instantiate(Mergedobject, transform.position, Quaternion.identity) as GameObject;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                hascollided = true;
                GameObject john = Instantiate(sloth, sloth.transform.position, Quaternion.identity) as GameObject;
                Destroy(spawn_script.questions);
                spawn_script.score += 50;
            }
        }
    }
}
