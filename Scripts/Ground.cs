using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float speed;

    private float posicaoInicial;
    private float posicaoFinal = -1.89f;
    void Start()
    {
        posicaoInicial = transform.position.x;
    }
    void Update()
    {
        if (transform.position.x <= posicaoFinal)
        {
            transform.position = new Vector3(posicaoInicial, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
