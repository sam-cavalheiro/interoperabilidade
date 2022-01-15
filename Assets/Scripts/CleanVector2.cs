using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Infelizmente foi necessário criar essa classe porque o JSON está tendo
// problemas para entender o Vector2 da Unity. Ou seja, essa é uma solução
// para prevenir um bug da Unity com JSON.
public struct CleanVector2
{
    public float x, y;

    public CleanVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public CleanVector2(Vector2 vector2)
    {
        this.x = vector2.x;
        this.y = vector2.y;
    }

    public Vector2 ToVector2()
    {
        return new Vector2(x, y);
    }
}
