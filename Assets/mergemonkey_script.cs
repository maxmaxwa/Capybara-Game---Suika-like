using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mergemonkey_script : MonoBehaviour
{
    int ID;
    public GameObject Mergedobject;
    private bool hascollided = false;

    // Start is called before the first frame update
    void Start()
    {
        ID = GetInstanceID();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("monkey"))
        {
            if (!hascollided)
            {
                if (ID < collision.gameObject.GetComponent<mergemonkey_script>().ID) { return; }
                Debug.Log($"merge{gameObject.name}");
                GameObject o = Instantiate(Mergedobject, transform.position, Quaternion.identity) as GameObject;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                hascollided = true;
                spawn_script.score += 20;
            }
        }
    }
}
