// See https://aka.ms/new-console-template for more information

public class Asciugatrice : Macchinario
{
    public Asciugatrice(string nome)
    {
        Stato = true;
        Gettoni = 0;
        Nome = nome;
        programmiAsciugatura = new ProgrammaAsciugatura[2];
        programmiAsciugatura[0] = new ProgrammaAsciugatura("Asciugatura rapida", 30, 2);
        programmiAsciugatura[1] = new ProgrammaAsciugatura("Asciugatura intensa", 60, 4);
        asciugaturaCorrente = new ProgrammaAsciugatura("nessuna", 0, 0);
    }
    public bool Stato { get; private set; }
    private ProgrammaAsciugatura[] programmiAsciugatura;
    public ProgrammaAsciugatura asciugaturaCorrente;
    public void NuovaAsciugatura()
    {
        Console.WriteLine("Digita:");
        Console.WriteLine("1 per Asciugatura rapida");
        Console.WriteLine("2 per Asciugatura intensa");
        //int scelta = Convert.ToInt32(Console.ReadLine());
        Random random = new Random();
        int scelta = random.Next(1, 3);
        if(scelta == 1 || scelta == 2)
        {
            asciugaturaCorrente.Nome = programmiAsciugatura[scelta - 1].Nome;
            asciugaturaCorrente.Tempo = programmiAsciugatura[scelta - 1].Tempo;
            asciugaturaCorrente.TempoRimanente = programmiAsciugatura[scelta - 1].Tempo;
            asciugaturaCorrente.Costo = programmiAsciugatura[scelta - 1].Costo;
            Gettoni += asciugaturaCorrente.Costo;
            Stato = false;
        }
                
        else
            Console.WriteLine("Digitato numero errato");
    }
    public override bool ControlloStato()
    {
        if (!Stato)
        {
            Random random = new Random();
            int finito = random.Next(1, 4);
            if (finito == 1 || asciugaturaCorrente.TempoRimanente == 0)
            {
                asciugaturaCorrente.TempoRimanente = 0;
                Stato = true;
            }
            else
            {
                asciugaturaCorrente.TempoRimanente = random.Next(0, asciugaturaCorrente.TempoRimanente);
            }
        }
        return Stato;
    }
    public override void DettagliMacchina()
    {
        string stato;
        if (ControlloStato())
            stato = "Vuota";
        else
            stato = "In esecuzione";
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Stato: " + stato);
        Console.WriteLine("Tempo alla fine dell'asciugatura: " + asciugaturaCorrente.TempoRimanente);
    }
}
