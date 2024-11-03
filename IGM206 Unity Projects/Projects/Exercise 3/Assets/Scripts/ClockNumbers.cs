using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    public GameObject clockNumberPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // instantiates clock number prefabs at the right positions around the clock
        GameObject number1 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos((2 * Mathf.PI) / 12) * 2.3f, Mathf.Sin((2 * Mathf.PI) / 12) * 2.3f, 0), Quaternion.identity);
        GameObject number2 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos((2 * Mathf.PI) * 2 / 12) * 2.3f, Mathf.Sin((2 * Mathf.PI) * 2 / 12) * 2.3f, 0), Quaternion.identity);
        GameObject number3 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos((2 * Mathf.PI) * 3 / 12) * 2.3f, Mathf.Sin((2 * Mathf.PI) * 3 / 12) * 2.3f, 0), Quaternion.identity);
        GameObject number4 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos((2 * Mathf.PI) * 4 / 12) * 2.3f, Mathf.Sin((2 * Mathf.PI) * 4 / 12) * 2.3f, 0), Quaternion.identity);
        GameObject number5 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos((2 * Mathf.PI) * 5 / 12) * 2.3f, Mathf.Sin((2 * Mathf.PI) * 5 / 12) * 2.3f, 0), Quaternion.identity);
        GameObject number6 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos((2 * Mathf.PI) * 6 / 12) * 2.3f, Mathf.Sin((2 * Mathf.PI) * 6 / 12) * 2.3f, 0), Quaternion.identity);
        GameObject number7 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos((2 * Mathf.PI) * 7 / 12) * 2.3f, Mathf.Sin((2 * Mathf.PI) * 7 / 12) * 2.3f, 0), Quaternion.identity);
        GameObject number8 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos((2 * Mathf.PI) * 8 / 12) * 2.3f, Mathf.Sin((2 * Mathf.PI) * 8 / 12) * 2.3f, 0), Quaternion.identity);
        GameObject number9 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos((2 * Mathf.PI) * 9 / 12) * 2.3f, Mathf.Sin((2 * Mathf.PI) * 9 / 12) * 2.3f, 0), Quaternion.identity);
        GameObject number10 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos((2 * Mathf.PI) * 10 / 12) * 2.3f, Mathf.Sin((2 * Mathf.PI) * 10 / 12) * 2.3f, 0), Quaternion.identity);
        GameObject number11 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos((2 * Mathf.PI) * 11 / 12) * 2.3f, Mathf.Sin((2 * Mathf.PI) * 11 / 12) * 2.3f, 0), Quaternion.identity);
        GameObject number12 = Instantiate(clockNumberPrefab, 
            new Vector3(Mathf.Cos(2 * Mathf.PI) * 2.3f, Mathf.Sin(2 * Mathf.PI) * 2.3f, 0), Quaternion.identity);

        // sets the textmesh for each clock number prefab to the correct number
        number1.GetComponent<TextMesh>().text = "2";
        number2.GetComponent<TextMesh>().text = "1";
        number3.GetComponent<TextMesh>().text = "12";
        number4.GetComponent<TextMesh>().text = "11";
        number5.GetComponent<TextMesh>().text = "10";
        number6.GetComponent<TextMesh>().text = "9";
        number7.GetComponent<TextMesh>().text = "8";
        number8.GetComponent<TextMesh>().text = "7";
        number9.GetComponent<TextMesh>().text = "6";
        number10.GetComponent<TextMesh>().text = "5";
        number11.GetComponent<TextMesh>().text = "4";
        number12.GetComponent<TextMesh>().text = "3";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
