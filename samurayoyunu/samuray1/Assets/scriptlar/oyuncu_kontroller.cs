using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class oyuncu_kontroller : MonoBehaviour
{
    
    private CharacterController karakterkontrol;
    public Transform kamera;
    private Vector3 oyuncu_konumu;
    private bool temas_oyuncu;
    [Range(50,500)]
    public float oyuncu_hizi;
    public float ziplama_yuksekligi;
    public float yercekimi_degeri;

    private void Start()
    {
        karakterkontrol = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        temas_oyuncu = karakterkontrol.isGrounded;
        if ( temas_oyuncu && oyuncu_konumu.y < 0)
        {
            oyuncu_konumu.y = 0f;
        }

        Vector3 konum = new Vector3(-Input.GetAxis("Horizontal"), 0f,-Input.GetAxis("Vertical"));
        karakterkontrol.Move(konum * Time.deltaTime * oyuncu_hizi);

        if (Input.GetKeyDown(KeyCode.Space) && temas_oyuncu)
        {
           oyuncu_konumu.y += Mathf.Sqrt(ziplama_yuksekligi * -3.0f * yercekimi_degeri);
        }

        oyuncu_konumu.y += yercekimi_degeri * Time.deltaTime;
        karakterkontrol.Move(oyuncu_konumu * Time.deltaTime);
    }
}
