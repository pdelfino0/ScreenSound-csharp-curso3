﻿using ScreenSound.Menus;
using ScreenSound.Models;

Banda banda1 = new Banda("Ira!");
banda1.AdicionarNota(new Avaliacao(10));
banda1.AdicionarNota(new Avaliacao(8));
banda1.AdicionarNota(new Avaliacao(6));
Banda banda2 = new Banda("The Beatles");
Dictionary<string, Banda> bandasRegistradas = new();

bandasRegistradas.Add(banda1.Nome, banda1);
bandasRegistradas.Add(banda2.Nome, banda2);

void ExibirLogo()
{
    Console.WriteLine(@"

                ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
                ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
                ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
                ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
                ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
                ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
                ");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para avaliar um album");
    Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    Dictionary<int, Menu> opcoes = new Dictionary<int, Menu>();
    opcoes.Add(1, new MenuRegistrarBanda());
    opcoes.Add(2, new MenuRegistrarAlbum());
    opcoes.Add(3, new MenuBandasRegistradas());
    opcoes.Add(4, new MenuAvaliarBanda());
    opcoes.Add(5, new MenuAvaliarAlbum());
    opcoes.Add(6, new MenuExibirDetalhes());

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        opcoes[opcaoEscolhidaNumerica].Executar(bandasRegistradas);
        ExibirOpcoesDoMenu();
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();