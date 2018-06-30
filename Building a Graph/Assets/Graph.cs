using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {
    public Transform pointCube;

    [Range(10,100)]
      public int res = 10;
    Transform[] poits;
	// Use this for initialization
	void Awake () {
        float step = 2f / res;
        Vector3 scale = Vector3.one * step;
        Vector3 postion;
        postion.z = 0;
        poits = new Transform[res];

        for (int i = 0; i < res; i++)
        {
            Transform point = Instantiate(pointCube);
            postion.x = (i + .5f) * step - 1f;
           postion.y = postion.x * postion.x;
            point.localPosition = postion;
            point.localScale = scale;

            //set a parent
            point.SetParent(transform,false);
            poits[i] = point;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < res; i++)
        {
            Transform point = poits[i];
            Vector3 postion = point.localPosition;
           postion.y = Mathf.Sin(Mathf.PI * (postion.x + Time.time));
         //  postion.y = postion.x * postion.x * postion.x;
            point.localPosition = postion;
           
        }
	}
}
