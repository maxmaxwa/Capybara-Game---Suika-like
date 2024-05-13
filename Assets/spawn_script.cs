using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class spawn_script : MonoBehaviour
{
    public GameObject tarantula;
    public GameObject frog;
    public GameObject parrot;
    static public float score = 0;
    public Text scoretext; 
    public Text deathtext;
    public GameObject debt;
    public GameObject dobt;
    public GameObject dibt;
    public GameObject dabt;
    static public bool pausedd;
    int randomnumber;

    static public GameObject questionca;
    static public GameObject questions;
    static public GameObject questionan;
    static public GameObject questionco;
    public GameObject question2ca;
    public GameObject question2s;
    public GameObject question2an;
    public GameObject question2co;
    private void Start()
    {
        int randomnumber = Random.Range(0, 101);
        if (randomnumber <= 50)
        {
            Instantiate(tarantula, transform.position, Quaternion.identity);
        }
        if (randomnumber <= 90 && randomnumber > 50)
        {
            Instantiate(frog, transform.position, Quaternion.identity);
        }
        if (randomnumber > 90)
        {
            GameObject a = Instantiate(parrot, transform.position, Quaternion.identity);
            a.tag = "p";
        }

        questionca = question2ca;
        questionca = Instantiate(questionca, questionca.transform.position, Quaternion.identity);

        questions = question2s;
        questions = Instantiate(questions, questions.transform.position, Quaternion.identity);

        questionan = question2an;
        questionan = Instantiate(questionan, questionan.transform.position, Quaternion.identity);

        questionco = question2co;
        questionco = Instantiate(questionco, questionco.transform.position, Quaternion.identity);


    }
    // Update is called once per frame
    void Update()
    {
        if (pausedd != true && general_script.alive == true )
        {
            if (Input.GetMouseButtonDown(0))
            {

                StartCoroutine(WaitForFunction());

            }
            scoretext.text = ("Score = " + score.ToString());
        }

        if (general_script.alive == false)
        {
            deathtext.text = ("You died, \nyou got " + score.ToString() + " points");
            debt.SetActive(true);
            dobt.SetActive(true);
            Destroy(scoretext);
            Destroy(dabt);
        }
    }

    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(0.5f);
        int randomnumber = Random.Range(0, 101);
        if (randomnumber <= 50)
        {
            Instantiate(tarantula, transform.position, Quaternion.identity);
        }
        if (randomnumber <= 90 && randomnumber > 50)
        {
            Instantiate(frog, transform.position, Quaternion.identity);
        }
        if (randomnumber > 90)
        {
            GameObject a = Instantiate(parrot, transform.position, Quaternion.identity);
            a.tag = "p";
        }
    }
    public void exitgame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void restartgame ()
    {
        SceneManager.LoadScene(0);
        debt.SetActive(true);
        dobt.SetActive(true);
        general_script.alive = true;
        score = 0;
    }
    public void paused ()
    {
        pausedd = true;
        dobt.SetActive(true);
        dibt.SetActive(true);
    }
    public void unpaused()
    {
        pausedd = false;
        dobt.SetActive(false);
        dibt.SetActive(false);
    }
    
    
}
