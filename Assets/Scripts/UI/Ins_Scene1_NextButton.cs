using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ins_Scene1_NextButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void InstructionMenuScene()
    {
        SceneManager.LoadScene(6);
    }
}
