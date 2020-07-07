﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPointsRightReceivedHandler : MonoBehaviour {

    //public GameObject handPointer;
    Vector3 position;
    Color color;
    int confiance = 3;

    void Start () {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void Update(){
        gameObject.transform.localPosition = position;
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }

    void HandleOnPointsRightReceived (HandInformation information) {
        position = information.position;
        confiance = information.confianceLevel;
        // handPointer.transform.rotation = information.quaternion;
        switch (information.confianceLevel) {
            case 0:
                color = Color.red;
                break;
            case 1:
                color =  Color.yellow;
                break;
            case 2:
                color =  Color.green;
                break;
            case 3:
                color = Color.blue;
                break;
            default:
                break;
        }
    }

    public int GetConfiance() { return confiance; }

    void OnEnable () {
        HandsTrackingHandler.OnPointsRightReceived += HandleOnPointsRightReceived;
    }

    void OnDisable () {
        HandsTrackingHandler.OnPointsRightReceived -= HandleOnPointsRightReceived;
    }

    

}