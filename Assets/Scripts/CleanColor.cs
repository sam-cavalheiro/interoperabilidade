using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Infelizmente foi necessário criar essa classe porque o JSON está tendo
// problemas para entender o Color da Unity. Ou seja, essa é uma solução
// para prevenir um bug da Unity com JSON.
public struct CleanColor
{
    public float r, g, b;

    public CleanColor(float r, float g, float b)
    {
        this.r = r;
        this.g = g;
        this.b = b;
    }

    public CleanColor(Color color)
    {
        this.r = color.r;
        this.g = color.g;
        this.b = color.b;
    }

    public Color ToColor()
    {
        return new Color(r, g, b, 1f);
    }
}
