using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public GameObject kamera;
    public Transform vucud;
    [Range(50,500)]
    public float hassasiyet;
    float kamera_acisi=0f;
    
    void Start()
    {
        
    }

    void Update()
    {
        float farex=Input.GetAxisRaw("Mouse X")*hassasiyet*Time.deltaTime;
        float farey=Input.GetAxisRaw("Mouse Y")*hassasiyet*Time.deltaTime;
        
        kamera_acisi -= farey;
        kamera_acisi=Mathf.Clamp(kamera_acisi,-80f,80f);

        transform.localRotation=UnityEngine.Quaternion.Euler(kamera_acisi,0f,0f);
        vucud.transform.Rotate(UnityEngine.Vector3.up*farex);
        
    }
}
