using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBala : MonoBehaviour
{

    public float speed = 2f, livingTime = 5f;
    public Vector2 direction;

    public Color initialColor = Color.white;
    public Color finalColor;

    private SpriteRenderer _renderer;
    private float _startTime;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
         
    }


    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        
        Destroy(this.gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    { 


        Vector2 movement = direction.normalized * speed * Time.deltaTime;
        transform.Translate(movement);

        float _timeSinceStarted = Time.time - _startTime;
        float _percebtageCompleted = _timeSinceStarted / livingTime;

        _renderer.color = Color.Lerp(initialColor,finalColor,_percebtageCompleted);
    }
} 
