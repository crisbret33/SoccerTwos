using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using System;

public class Timer : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI textoTimer;
    public GameObject menuFinPartida;
    public Funcionesbotones fb;  
    public GameObject multi;
    public GameObject uni;

    void Start()
    {
        timer = 120; // 300 == 5 mins
        if(fb.multijugador == 1){                   
            multi.SetActive(true);
            uni.SetActive(false);
        } 
        else{
            uni.SetActive(true);
            multi.SetActive(false);
        } 
    }
    void Update()
    {
        if(timer <= 0){
            menuFinPartida.SetActive(true);
        } 
        else{
            timer -= Time.deltaTime;

            if(timer > 60){
                int minutos = (int) (timer / 60);
                int segs = (int) (timer % 60);
                if(minutos < 10){
                    if(segs <= 9) textoTimer.text = "0" + minutos.ToString("f0") + ":0" + segs.ToString("f0");
                    else textoTimer.text = "0" + minutos.ToString("f0") + ":" + segs.ToString("f0");
                } 
                else{
                    if(segs <= 9) textoTimer.text = minutos.ToString("f0") + ":0" + segs.ToString("f0");
                    else textoTimer.text = minutos.ToString("f0") + ":" + segs.ToString("f0");
                } 
            }
            else{
                int segs = (int) (timer % 60);
                if(segs < 10) textoTimer.text = "00:0" + segs.ToString("f0");
                else textoTimer.text = "00:" + segs.ToString("f0");

            }
        }
    }
}
