using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotCar : MonoBehaviour
{
    // Update is called once per frame
    // bot-car auto-movement speed
    void Update() {
        Vector3 moveDir = new Vector3(0, 0, 5);
        transform.position += moveDir * Time.deltaTime;
    }
}
