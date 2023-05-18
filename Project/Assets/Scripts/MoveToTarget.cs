using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public GameObject target;

     void Update() {
        //float randomSpeed = Random.Range(0.01f,0.1f);
        //Vector3.MoveToward(시작 지점, 목표지점, 이동속도)
        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, Enemy.speed * Time.deltaTime);        

        //Vector3.Lerp(시작 위치, 목표 위치, 0~1 사이의 숫자)
        //transform.position = Vector3.Lerp(gameObject.transform.position, target.transform.position, 0.001f);  

        //구형 이동: Vector3.SLerp(시작 위치, 목표 위치, 0~1 사이의 숫자)
    }

}
