using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    private AudioSource finishsoundEffect;
    private bool levelCompleted = false; // to check that the sound of levelfinish will only play once
    // Start is called before the first frame update
    private void Start()
    {
        finishsoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishsoundEffect.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f); // to keep delay in switching the level
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
