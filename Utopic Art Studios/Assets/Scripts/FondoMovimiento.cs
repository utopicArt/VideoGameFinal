using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    [SerializeField] private Vector2 _velocidadMovimiento;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D _jugadorRB;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        _jugadorRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_jugadorRB != null)
        {
            offset = (_jugadorRB.velocity.x * 0.1f) * _velocidadMovimiento * Time.deltaTime;
            material.mainTextureOffset += offset;
        }
    }
}
