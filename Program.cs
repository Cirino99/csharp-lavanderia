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
