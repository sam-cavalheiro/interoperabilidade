using System;
using System.Collections.Generic;
using System.Linq;

public class Partida
{
    public Corredor Corredor1;
    public Corredor Corredor2;
    public int MaximoVoltas;

    public Partida()
    {
        Corredor1 = new Corredor();
        Corredor2 = new Corredor();
    }
}