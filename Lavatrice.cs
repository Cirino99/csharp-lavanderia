// See https://aka.ms/new-console-template for more information

public class Lavatrice : Macchinario
{
    public Lavatrice(string nome) {
        Stato = true;
        Gettoni = 0;
        Detersivo = 1000;
        Ammorbidente = 500;
        Nome = nome;
        ProgrammiLavaggio = new ProgrammaLavaggio[3];
        ProgrammiLavaggio[0] = new ProgrammaLavaggio("Lavaggio Rinfrescante", 20, 2, 20, 5);
        ProgrammiLavaggio[1] = new ProgrammaLavaggio("Lavaggio Rinnovante", 40, 3, 40, 10);
        ProgrammiLavaggio[2] = new ProgrammaLavaggio("Lavaggio Sgrassante", 60, 4, 60, 15);
        LavaggioCorrente = new ProgrammaLavaggio("nessuna", 0, 0, 0, 0);
    }
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }
    public bool Stato { get; private set; }
    private ProgrammaLavaggio[] ProgrammiLavaggio;
    public ProgrammaLavaggio LavaggioCorrente;
    public void NuovoLavaggio()
    {
        Console.WriteLine("Digita:");
        Console.WriteLine("1 per Lavaggio Rinfrescante");
        Console.WriteLine("2 per Lavaggio Rinnovante");
        Console.WriteLine("3 per Lavaggio Sgrassante");
        //int scelta = Convert.ToInt32(Console.ReadLine());
        Random random = new Random();
        int scelta = random.Next(1, 4);
        if (scelta == 1 || scelta == 2 || scelta == 3)
        {
            if (Detersivo - ProgrammiLavaggio[scelta - 1].ConsumoDetersivo > 0 && Ammorbidente - ProgrammiLavaggio[scelta - 1].ConsumoAmmorbidente > 0)
            {
                LavaggioCorrente.Nome = ProgrammiLavaggio[scelta - 1].Nome;
                LavaggioCorrente.Tempo = ProgrammiLavaggio[scelta - 1].Tempo;
                LavaggioCorrente.TempoRimanente = ProgrammiLavaggio[scelta - 1].Tempo;
                LavaggioCorrente.Costo = ProgrammiLavaggio[scelta - 1].Costo;
                LavaggioCorrente.ConsumoDetersivo = ProgrammiLavaggio[scelta - 1].ConsumoDetersivo;
                LavaggioCorrente.ConsumoAmmorbidente = ProgrammiLavaggio[scelta - 1].ConsumoAmmorbidente;
                Gettoni += LavaggioCorrente.Costo;
                Detersivo -= LavaggioCorrente.ConsumoDetersivo;
                Ammorbidente -= LavaggioCorrente.ConsumoAmmorbidente;
                Stato = false;
            }
        }
        else
            Console.WriteLine("Digitato numero errato");
    }
    public override bool ControlloStato()
    {
        if(!Stato)
        {
            Random random = new Random();
            int finito = random.Next(1, 4);
            if(finito == 1 || LavaggioCorrente.TempoRimanente == 0)
            {
                LavaggioCorrente.TempoRimanente = 0;
                Stato = true;
            } else
            {
                LavaggioCorrente.TempoRimanente = random.Next(0, LavaggioCorrente.TempoRimanente);
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
        Console.WriteLine("Detersivo rimanente: " + Detersivo + "ml");
        Console.WriteLine("Ammorbidente rimanente: " + Ammorbidente + "ml");
        Console.WriteLine("Tempo alla fine del lavaggio: " + LavaggioCorrente.TempoRimanente);
    }
}