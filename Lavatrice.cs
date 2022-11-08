// See https://aka.ms/new-console-template for more information

public class Lavatrice : Macchinario
{
    public Lavatrice(string nome) {
        Stato = true;
        Gettoni = 0;
        Detersivo = 1000;
        Ammorbidente = 500;
        Nome = nome;
        Programmi = new ProgrammaLavaggio[3];
        Programmi[0] = new ProgrammaLavaggio("Lavaggio Rinfrescante", 20, 2, 20, 5);
        Programmi[1] = new ProgrammaLavaggio("Lavaggio Rinnovante", 40, 3, 40, 10);
        Programmi[2] = new ProgrammaLavaggio("Lavaggio Sgrassante", 60, 4, 60, 15);
        ProgrammaCorrente = new ProgrammaLavaggio("nessuna", 0, 0, 0, 0);
    }
    public ProgrammaLavaggio ProgrammaCorrente
    {
        get
        {
            return (ProgrammaLavaggio)base.ProgrammaCorrente;
        }
        protected set
        {
            base.ProgrammaCorrente = value;
        }
    }
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }
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
            if (Detersivo - GetProgrammaLavaggio(scelta).ConsumoDetersivo > 0 && Ammorbidente - GetProgrammaLavaggio(scelta).ConsumoAmmorbidente > 0)
            {
                ProgrammaCorrente.Nome = GetProgrammaLavaggio(scelta).Nome;
                ProgrammaCorrente.Tempo = GetProgrammaLavaggio(scelta).Tempo;
                ProgrammaCorrente.TempoRimanente = GetProgrammaLavaggio(scelta).Tempo;
                ProgrammaCorrente.Costo = GetProgrammaLavaggio(scelta).Costo;
                ProgrammaCorrente.ConsumoDetersivo = GetProgrammaLavaggio(scelta).ConsumoDetersivo;
                ProgrammaCorrente.ConsumoAmmorbidente = GetProgrammaLavaggio(scelta).ConsumoAmmorbidente;
                Gettoni += ProgrammaCorrente.Costo;
                Detersivo -= ProgrammaCorrente.ConsumoDetersivo;
                Ammorbidente -= ProgrammaCorrente.ConsumoAmmorbidente;
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
            if(finito == 1 || ProgrammaCorrente.TempoRimanente == 0)
            {
                ProgrammaCorrente.TempoRimanente = 0;
                Stato = true;
            } else
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
        Console.WriteLine("Detersivo rimanente: " + Detersivo + "ml");
        Console.WriteLine("Ammorbidente rimanente: " + Ammorbidente + "ml");
        Console.WriteLine("Tempo alla fine del lavaggio: " + ProgrammaCorrente.TempoRimanente);
    }

    private ProgrammaLavaggio GetProgrammaLavaggio(int scelta)
    {
        return (ProgrammaLavaggio)Programmi[scelta - 1];
    }
}