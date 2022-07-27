using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public GameObject player;
    public GameObject initialPosition;
    private Animator _animator;
    public float time;

    private void Start()
    {
        time = 10f;
        initialPosition = GameObject.Find("PlayerInitialPosition");
        _animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            _animator.SetBool("time0ut", true);
            _animator.SetTrigger("timeOut");
            StartCoroutine(waitUntilTimeOutAnim(0.5f));
            if (initialPosition && !_animator.GetCurrentAnimatorStateInfo(0).IsName("timeOut"))
            {
                Vector3 absolutePosition = initialPosition.transform.position;
                player.transform.position = absolutePosition;
                Debug.Log("Posicion reseteada: " + absolutePosition);
                _animator.SetBool("time0ut", false);
                time = 10f;
            }
        }
    }

    private IEnumerator waitUntilTimeOutAnim(float waitTime)
    {
        Debug.Log("0WaitAndPrint " + Time.time);
        yield return new WaitForSeconds(waitTime); 
        Debug.Log("1WaitAndPrint " + Time.time);
    }
}
