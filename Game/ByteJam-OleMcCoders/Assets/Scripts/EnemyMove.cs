using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
     Transform target;
    public Transform myTrans;
    public int Speed;
    // Start is called before the first frame update


    // Update is called once per frame
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {

        transform.LookAt(target);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

    }
}
