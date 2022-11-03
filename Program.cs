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
            Console.WriteLine(lavatrici[i].Nome + ": " + lavatrici[i].ControlloStato());
            Console.WriteLine(asciugatrici[i].Nome + ": " + asciugatrici[i].ControlloStato());
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
            if (lavatrici[i].ControlloStato() == "Vuota")
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
            if (asciugatrici[i].ControlloStato() == "Vuota")
            {
                asciugatrici[i].NuovaAsciugatura();
            }
        }
    }
}

public class Lavatrice
{
    public Lavatrice(string nome) {
        Stato = "Vuota";
        Gettoni = 0;
        Detersivo = 1000;
        Ammorbidente = 500;
        Nome = nome;
    }
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }
    public int Gettoni { get; set; }
    public string Stato { get; private set; }
    public int Tempo { get; private set; }
    public string Nome { get; set; }
    private void Rinfrescante()
    {
        if(Detersivo - 20 > 0 && Ammorbidente - 5 > 0)
        {
            Detersivo -= 20;
            Ammorbidente -= 5;
            Stato = "Lavaggio Rinfrescante in funzione";
            Tempo = 20;
            Gettoni += 2;
        }
    }
    private void Rinnovante()
    {
        if (Detersivo - 40 > 0 && Ammorbidente - 10 > 0)
        {
            Detersivo -= 40;
            Ammorbidente -= 10;
            Stato = "Lavaggio Rinnovante in funzione";
            Tempo = 40;
            Gettoni += 3;
        }
    }
    private void Sgrassante()
    {
        if (Detersivo - 60 > 0 && Ammorbidente - 15 > 0)
        {
            Detersivo -= 60;
            Ammorbidente -= 16;
            Stato = "Lavaggio Sgrassante in funzione";
            Tempo = 60;
            Gettoni += 4;
        }
    }
    public void NuovoLavaggio()
    {
        Console.WriteLine("Digita:");
        Console.WriteLine("1 per Lavaggio Rinfrescante");
        Console.WriteLine("2 per Lavaggio Rinnovante");
        Console.WriteLine("3 per Lavaggio Sgrassante");
        //int scelta = Convert.ToInt32(Console.ReadLine());
        Random random = new Random();
        int scelta = random.Next(1, 4);
        switch (scelta)
        {
            case 1:
                Rinfrescante();
                break;
            case 2:
                Rinnovante();
                break;
            case 3:
                Sgrassante();
                break;
            default: 
                Console.WriteLine("Digitato numero errato");
                break;
        }
    }
    public string ControlloStato()
    {
        if(Stato != "Vuota")
        {
            Random random = new Random();
            int finito = random.Next(1, 4);
            if(finito == 1 || Tempo == 0)
            {
                Tempo = 0;
                Stato = "Vuota";
            } else
            {
                Tempo = random.Next(0, Tempo);
            }
        }
        return Stato;
    }
    public void DettagliMacchina()
    {
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Stato: " + ControlloStato());
        Console.WriteLine("Detersivo rimanente: " + Detersivo + "ml");
        Console.WriteLine("Ammorbidente rimanente: " + Ammorbidente + "ml");
        Console.WriteLine("Tempo alla fine del lavaggio: " + Tempo);
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
        Stato = "Vuota";
        Gettoni = 0;
        Nome = nome;
    }
    public int Gettoni { get; set; }
    public string Stato { get; private set; }
    public int Tempo { get; private set; }
    public string Nome { get; set; }
    private void Rapido()
    {
        Stato = "Asciugatura rapida in funzione";
        Tempo = 30;
        Gettoni += 2;
    }
    private void Intenso()
    {
        Stato = "Asciugatura intensa in funzione";
        Tempo = 60;
        Gettoni += 4;
    }

    public void NuovaAsciugatura()
    {
        Console.WriteLine("Digita:");
        Console.WriteLine("1 per Asciugatura rapida");
        Console.WriteLine("2 per Asciugatura intensa");
        //int scelta = Convert.ToInt32(Console.ReadLine());
        Random random = new Random();
        int scelta = random.Next(1, 3);
        switch (scelta)
        {
            case 1:
                Rapido();
                break;
            case 2:
                Intenso();
                break;
            default:
                Console.WriteLine("Digitato numero errato");
                break;
        }
    }
    public string ControlloStato()
    {
        if (Stato != "Vuota")
        {
            Random random = new Random();
            int finito = random.Next(1, 4);
            if (finito == 1 || Tempo == 0)
            {
                Tempo = 0;
                Stato = "Vuota";
            }
            else
            {
                Tempo = random.Next(0, Tempo);
            }
        }
        return Stato;
    }
    public void DettagliMacchina()
    {
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Stato: " + ControlloStato());
        Console.WriteLine("Tempo alla fine dell'asciugatura: " + Tempo);
    }
    public double Incasso()
    {
        return (double)Gettoni * 0.50;
    }
}