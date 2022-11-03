// See https://aka.ms/new-console-template for more information

Lavatrice lavatrice = new Lavatrice("prova");
lavatrice.DettagliMacchina();
for (int i=0; i<10; i++)
{
    lavatrice.Rinfrescante();
    lavatrice.DettagliMacchina();
}
Console.WriteLine(lavatrice.Incasso());

public class Lavanderia
{

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
    public void Rinfrescante()
    {
        if(Detersivo - 20 > 0 && Ammorbidente - 5 > 0 && ControlloStato() == "Vuota")
        {
            Detersivo -= 20;
            Ammorbidente -= 5;
            Stato = "Lavaggio Rinfrescante in funzione";
            Tempo = 20;
            Gettoni += 2;
        }
    }
    public void Rinnovante()
    {
        if (Detersivo - 40 > 0 && Ammorbidente - 10 > 0 && ControlloStato() == "Vuota")
        {
            Detersivo -= 40;
            Ammorbidente -= 10;
            Stato = "Lavaggio Rinfrescante in funzione";
            Tempo = 40;
            Gettoni += 3;
        }
    }
    public void Sgrassante()
    {
        if (Detersivo - 60 > 0 && Ammorbidente - 15 > 0 && ControlloStato() == "Vuota")
        {
            Detersivo -= 60;
            Ammorbidente -= 16;
            Stato = "Lavaggio Rinfrescante in funzione";
            Tempo = 60;
            Gettoni += 4;
        }
    }
    private string ControlloStato()
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
    public void Rapido()
    {
        if (ControlloStato() == "Vuota")
        {
            Stato = "Asciugatura rapida in funzione";
            Tempo = 30;
            Gettoni += 2;
        }
    }
    public void Intenso()
    {
        if (ControlloStato() == "Vuota")
        {
            Stato = "Asciugatura intensa in funzione";
            Tempo = 60;
            Gettoni += 4;
        }
    }
    private string ControlloStato()
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