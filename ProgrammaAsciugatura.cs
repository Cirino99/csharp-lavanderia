// See https://aka.ms/new-console-template for more information

public class ProgrammaAsciugatura
{
    public ProgrammaAsciugatura(string nome, int tempo, int costo)
    {
        Tempo = tempo;
        TempoRimanente = 0;
        Nome = nome;
        Costo = costo;
    }
    public int Tempo { get; set; }
    public int TempoRimanente { get; set; }
    public string Nome { get; set; }
    public int Costo { get; set; }
}