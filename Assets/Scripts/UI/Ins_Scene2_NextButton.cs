using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ins_Scene2_NextButton : MonoBehaviour
{ 
    public void NextButton()
    {
        SceneManager.LoadScene(7);
    }
}
