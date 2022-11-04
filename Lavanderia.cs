// See https://aka.ms/new-console-template for more information

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
