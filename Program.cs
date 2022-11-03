// See https://aka.ms/new-console-template for more information

Lavanderia lavanderia = new Lavanderia();
bool fine = false;
do
{
    Console.WriteLine("Scegli: ");
    Console.WriteLine("1 Stato Macchine");
    Console.WriteLine("2 Dettagli Macchina");
    Console.WriteLine("3 programa Lavatrici");
    Console.WriteLine("4 programma Asciugatrici");
    Console.WriteLine("5 incasso");
    Console.WriteLine("6 esci");
    int scelta = Convert.ToInt32(Console.ReadLine());
    switch (scelta)
    {
        case 1:
            lavanderia.StatoMacchine();
            break;
        case 2:
            Console.WriteLine("Digita il tipo di macchina (lavatrice o asciugatrice)");
            string macchina = Console.ReadLine();
            Console.WriteLine("Digita il numero della macchina (da 1 a 5)");
            int numero = Convert.ToInt32(Console.ReadLine());
            lavanderia.DettagliMacchina(macchina,numero);
            break;
        case 3:
            lavanderia.ProgrammaLavatrici();
            break;
        case 4:
            lavanderia.ProgrammaAsciugatrici();
            break;
        case 5:
            lavanderia.Incasso();
            break;
        default:
            fine = true;
            break;
    }
} while (!fine);

public class Lavanderia
{
    public Lavanderia()
    {
        lavatrici = new Lavatrice[5];
        asciugatrici = new Asciugatrice[5];
        for (int i=0; i<5; i++)
        {
            lavatrici[i] = new Lavatrice("Lavatrice" + (i + 1));
            asciugatrici[i] = new Asciugatrice("Asciugatrice" + (i + 1));
        }
    }
    private Lavatrice[] lavatrici;
    private Asciugatrice[] asciugatrici;

    public void StatoMacchine()
    {
        Console.Clear();
        Console.WriteLine("Stato generale:");
        for (int i=0; i<lavatrici.Length; i++)
        {
            string statoLavatrice;
            if (lavatrici[i].ControlloStato())
                statoLavatrice = "Vuota";
            else
                statoLavatrice = "In esecuzione";
            string statoAsciugatrice;
            if (asciugatrici[i].ControlloStato())
                statoAsciugatrice = "Vuota";
            else
                statoAsciugatrice = "In esecuzione";
            Console.WriteLine(lavatrici[i].Nome + ": " + statoLavatrice);
            Console.WriteLine(asciugatrici[i].Nome + ": " + statoAsciugatrice);
        }
    }
    public void DettagliMacchina(string macchina, int numero)
    {
        Console.Clear();
        Console.WriteLine("Dettagli:");
        if (macchina == "lavatrice")
            lavatrici[numero - 1].DettagliMacchina();
        else
            asciugatrici[numero - 1].DettagliMacchina();
    }
    public void Incasso()
    {
        Console.Clear();
        Console.WriteLine("Incassi:");
        double incassoTotale = 0;
        for(int i=0; i<lavatrici.Length; i++)
        {
            Console.WriteLine(lavatrici[i].Nome + ": " + lavatrici[i].Incasso() + "$");
            Console.WriteLine(asciugatrici[i].Nome + ": " + asciugatrici[i].Incasso() + "$");
            incassoTotale = incassoTotale + lavatrici[i].Incasso() + asciugatrici[i].Incasso();
        }
        Console.WriteLine("Totale: " + incassoTotale + "$");
    }
    public void ProgrammaLavatrici()
    {
        for(int i = 0; i < lavatrici.Length; i++)
        {
            if (lavatrici[i].ControlloStato())
            {
                lavatrici[i].NuovoLavaggio();
                break;
            }
        }
    }
    public void ProgrammaAsciugatrici()
    {
        for (int i = 0; i < asciugatrici.Length; i++)
        {
            if (asciugatrici[i].ControlloStato())
            {
                asciugatrici[i].NuovaAsciugatura();
            }
        }
    }
}

public class Lavatrice
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
    public int Gettoni { get; set; }
    public bool Stato { get; private set; }
    public string Nome { get; set; }
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
            }
        }
        else
            Console.WriteLine("Digitato numero errato");
    }
    public bool ControlloStato()
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
    public void DettagliMacchina()
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
    public double Incasso()
    {
        return (double)Gettoni * 0.50;
    }
}

public class Asciugatrice
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
    public int Gettoni { get; set; }
    public bool Stato { get; private set; }
    public string Nome { get; set; }
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
        }
                
        else
            Console.WriteLine("Digitato numero errato");
    }
    public bool ControlloStato()
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
    public void DettagliMacchina()
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
    public double Incasso()
    {
        return (double)Gettoni * 0.50;
    }
}

public class ProgrammaLavaggio
{
    public ProgrammaLavaggio(string nome, int tempo, int costo, int consumoDetersivo, int consumoAmmorbidente)
    {
        Tempo = tempo;
        TempoRimanente = 0;
        Nome = nome;
        Costo = costo;
        ConsumoDetersivo = consumoDetersivo;
        ConsumoAmmorbidente = consumoAmmorbidente;
    }
    public int Tempo { get; set; }
    public int TempoRimanente { get; set; }
    public string Nome { get; set; }
    public int Costo { get; set; }
    public int ConsumoDetersivo { get; set; }
    public int ConsumoAmmorbidente { get; set; }
}

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