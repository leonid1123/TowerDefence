using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextController : MonoBehaviour
{
    public TMP_Text waveNumberText;
    public TMP_Text countDownText;
    public WaveSpawner waveSpawner;

    void Update()
    {
        waveNumberText.text = "Номер волны:" + waveSpawner.GetWave().ToString();
        countDownText.text = "До новой волны: " + Mathf.Floor(waveSpawner.GetCountdown()).ToString();
      
    }
}
