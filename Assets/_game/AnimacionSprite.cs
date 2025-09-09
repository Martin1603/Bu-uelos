using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimacionSprite : MonoBehaviour
{
    public Sprite[] imagenes; // Array de imágenes
    public float frecuenciaCambio = 0.5f; // Frecuencia de cambio de imagen (en segundos)
    private SpriteRenderer spr; // Componente SpriteRenderer
    private int indiceImagen = 0; // Índice de la imagen actual
    private float tiempoPasado = 0f; // Tiempo transcurrido desde el último cambio de imagen

    void Start()
    {
        spr = GetComponent<SpriteRenderer>(); // Obtiene el SpriteRenderer
    }

    void Update()
    {
        // Acumula el tiempo transcurrido
        tiempoPasado += Time.deltaTime;

        // Si el tiempo transcurrido es mayor o igual que la frecuencia de cambio
        if (tiempoPasado >= frecuenciaCambio)
        {
            // Cambia la imagen al siguiente sprite en el array
            indiceImagen = (indiceImagen + 1) % imagenes.Length; // Cicla entre las imágenes
            spr.sprite = imagenes[indiceImagen]; // Actualiza el sprite en el SpriteRenderer

            // Reinicia el contador de tiempo
            tiempoPasado = 0f;
        }
    }
}

