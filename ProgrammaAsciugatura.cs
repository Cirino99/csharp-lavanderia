// See https://aka.ms/new-console-template for more information

public class ProgrammaAsciugatura : Programma
{
    public ProgrammaAsciugatura(string nome, int tempo, int costo)
    {
        Tempo = tempo;
        TempoRimanente = 0;
        Nome = nome;
        Costo = costo;
    }
}