

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaBandas = new List<string> {"Black Sabbath", "The Beatles", "Iron Maiden"};
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Black Sabbath", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("ACDC", new List<int>());

void ExibirLogo()
{

    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
}




void ExibirOpcoesDoMenu()
{
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("digite -1 para sair");


    Console.Write("\nDigite a sua opção: ");
    int opcao = 0;
    try
    {
        opcao = int.Parse(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine("Opção invalida!!! \n" + ex);
    }

    switch (opcao)
    {
        case 1: Registrarbandas(); break;
        case 2: MostrarBandasRegistradas(); break;
        case 3: AvaliarBanda(); break;
        case 4: MediaBanda(); break;
        case -1: Console.WriteLine("Você saiu do programa!"); break;
        default: Console.WriteLine("opção invalida!"); break;

    }



}

void Registrarbandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de bandas");
    Console.WriteLine("Digite uma banda para registrar: ");
    string banda = Console.ReadLine()!;

    bandasRegistradas.Add(banda, new List<int>());

    Console.WriteLine($"Você cadastrou a banda {banda}");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}


void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Bandas registradas");
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine(banda.ToString());
    }
    Thread.Sleep(3000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.WriteLine("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        Console.Write($"Qual a nota que deseja dar para a banda {nomeBanda}:");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso para a banda {nomeBanda}.");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
    else
    {
        Console.WriteLine($"A Banda {nomeBanda} não foi encontada!");
        Console.WriteLine("Digite uma tecla para voltar para o menu");
        Console.ReadKey();
        ExibirOpcoesDoMenu();
    }
}

void MediaBanda()
{
    ExibirTituloDaOpcao("Média da banda");
    Console.Clear();
    Console.WriteLine("Qual banda você deseja exibir a média?:");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    
        double media = bandasRegistradas[nomeBanda].Average();
        Console.WriteLine($"A banda {nomeBanda} possui uma média de {media}");
    }
    else
    {
        Console.WriteLine($"Banda {nomeBanda} não encontrada!!!");
        Thread.Sleep(3000);
        ExibirOpcoesDoMenu();
    }


}

void ExibirTituloDaOpcao(string titulo)
{
    int letrasCount = titulo.Length;
    string asterisco = string.Empty.PadLeft(letrasCount, '*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

ExibirLogo();
ExibirOpcoesDoMenu();