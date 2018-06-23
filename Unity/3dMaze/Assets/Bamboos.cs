using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bamboos : MonoBehaviour {

    public Transform[] bamboos;

    // Use this for initialization
    private void Awake()
    {
        bamboos = new Transform[transform.childCount];
        for (int i = 0; i < bamboos.Length; i++)
        {
            bamboos[i] = transform.GetChild(i);
            bamboos[i].transform.localRotation = Quaternion.Euler(0, Random.value * 360, 0);
        }
    }
}
