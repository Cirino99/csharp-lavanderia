﻿// See https://aka.ms/new-console-template for more information

public abstract class Macchinario : IIncasso
{
    public string Nome { get; set; }
    public int Gettoni { get; set; }
    public abstract bool ControlloStato();
    public abstract void DettagliMacchina();
    public double Incasso()
    {
        return (double)Gettoni * 0.50;
    }
}

public interface IIncasso
{
    public double Incasso();
}