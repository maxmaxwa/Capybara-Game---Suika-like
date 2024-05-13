using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mergecoati_script : MonoBehaviour
{
    int ID;
    public GameObject Mergedobject;
    private bool hascollided = false;
    public GameObject anteater;

    // Start is called before the first frame update
    void Start()
    {
        ID = GetInstanceID();
    }

    void Update()
    {
        if (transform.position.y <= -3.7)
        {
            gameObject.transform.position = new Vector2(transform.position.x, -3.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coati"))
        {
            if (!hascollided)
            {
                if (ID < collision.gameObject.GetComponent<mergecoati_script>().ID) { return; }
                Debug.Log($"merge{gameObject.name}");
                GameObject o = Instantiate(Mergedobject, transform.position, Quaternion.identity) as GameObject;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                hascollided = true;
                GameObject greg = Instantiate(anteater, anteater.transform.position, Quaternion.identity) as GameObject;
                Destroy(spawn_script.questionan);
                spawn_script.score += 40;
            }
        }
    }
}