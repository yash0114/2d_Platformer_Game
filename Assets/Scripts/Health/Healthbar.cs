using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health Playerhealth;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;


    private void Start()
    {
        totalhealthbar.fillAmount = Playerhealth.currentHealth / 10; // will be updated only once
    }

    private void Update()
    {
        currenthealthbar.fillAmount = Playerhealth.currentHealth / 10;   // we want current health bar to update continuously
    }
}
