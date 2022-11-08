// See https://aka.ms/new-console-template for more information

public class Asciugatrice : Macchinario
{
    public Asciugatrice(string nome)
    {
        Stato = true;
        Gettoni = 0;
        Nome = nome;
        Programmi = new ProgrammaAsciugatura[2];
        Programmi[0] = new ProgrammaAsciugatura("Asciugatura rapida", 30, 2);
        Programmi[1] = new ProgrammaAsciugatura("Asciugatura intensa", 60, 4);
        ProgrammaCorrente = new ProgrammaAsciugatura("nessuna", 0, 0);
    }
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
            ProgrammaCorrente.Nome = Programmi[scelta - 1].Nome;
            ProgrammaCorrente.Tempo = Programmi[scelta - 1].Tempo;
            ProgrammaCorrente.TempoRimanente = Programmi[scelta - 1].Tempo;
            ProgrammaCorrente.Costo = Programmi[scelta - 1].Costo;
            Gettoni += ProgrammaCorrente.Costo;
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
            if (finito == 1 || ProgrammaCorrente.TempoRimanente == 0)
            {
                ProgrammaCorrente.TempoRimanente = 0;
                Stato = true;
            }
            else
            {
                ProgrammaCorrente.TempoRimanente = random.Next(0, ProgrammaCorrente.TempoRimanente);
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
        Console.WriteLine("Tempo alla fine dell'asciugatura: " + ProgrammaCorrente.TempoRimanente);
    }
}
