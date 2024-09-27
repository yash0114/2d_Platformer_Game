using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Coin = 0;
    [SerializeField] private Text CoinText;

    // audio for collectible
    [SerializeField] private AudioSource coinsoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            coinsoundEffect.Play();
            Destroy(collision.gameObject);
            Coin++;
            CoinText.text = " : " + Coin;
        }
    }
}
