using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    public TextMeshProUGUI dialogTMP;
    public GameObject messageContainer;
    public float velocidadEscritura = 0.06f;
    public float velocidadCambio = 1f;
    public List<string> textElements = new List<string>();
    public bool endPoint = false;

    private void Awake()
    {
        verifyStrings();
    }

    void Start()
    {
    }

    private void verifyStrings()
    {
        for (int i = 0; i < textElements.Count; i++)
            textElements[i] = checksize(textElements[i]);
    }

    private string checksize(string text)
    {
        if (text.Length > 100)
        {
            text = text.Substring(0, 100);
        }
        return text;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 dialogPosition = new Vector3(
            gameObject.transform.position.x,
            gameObject.transform.position.y + 0.5f,
            gameObject.transform.position.z);
        messageContainer.transform.position = dialogPosition;
        messageContainer.SetActive(true);
        StartCoroutine("mostrarDialogo");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        messageContainer.SetActive(false);
        StopCoroutine("mostrarDialogo");
    }

    IEnumerator mostrarDialogo()
    {
        foreach (string texto in textElements)
        {
            dialogTMP.text = "";
            foreach (char caracter in texto.ToCharArray())
            {
                dialogTMP.text += caracter;
                yield return new WaitForSeconds(velocidadEscritura);//Espera entre mostrar caracteres
            }
            Debug.Log("Siguiente mensaje");
            yield return new WaitForSeconds(velocidadCambio); //Espera entre mensajes
        }
        Debug.Log("El End Point es " + endPoint);
        if (endPoint)
        {
            Debug.Log("Entro al if");
            yield return new WaitForSeconds(3f); //Espera para finalizar el nivel
            SceneManager.LoadScene(0);
        }
    }
}
