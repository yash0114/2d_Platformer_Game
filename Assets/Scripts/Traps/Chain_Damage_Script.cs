using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Damage_Script : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            PlayerManager.isGameOver = true;
        }
    }
}
