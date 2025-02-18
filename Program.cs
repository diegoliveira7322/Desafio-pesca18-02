using System;
using System.Collections.Generic;

class Programa
{
    static void Main()
    {
        Jogo();
    }

    static void Jogo()
    {
        Console.Write("Quantidade de peixes no lago: ");
        int numPeixesLago = int.Parse(Console.ReadLine());
        Console.Write("Quantos jogadores: ");
        int numJogadores = int.Parse(Console.ReadLine());

        List<Jogador> jogadores = new List<Jogador>();
        Random rand = new Random();

        for (int i = 0; i < numJogadores; i++)
        {
            Console.Write($"Nome do {i + 1}° Jogador: ");
            string nome = Console.ReadLine();
            Console.Write("Quantidade de iscas: ");
            int qntIscas = int.Parse(Console.ReadLine());

            jogadores.Add(new Jogador { Nome = nome, Iscas = qntIscas, Peixes = 0 });
        }

        HashSet<int> lago = new HashSet<int>();
        while (lago.Count < numPeixesLago)
        {
            lago.Add(rand.Next(1, 51));
        }

        Console.WriteLine("Jogo iniciado!");
        while (jogadores.Exists(j => j.Iscas > 0))
        {
            foreach (var jogador in jogadores)
            {
                if (jogador.Iscas > 0)
                {
                    Console.WriteLine($"É a vez de {jogador.Nome}. Escolha uma posição (1-50): ");
                    int tentativa = int.Parse(Console.ReadLine());

                    if (lago.Contains(tentativa))
                    {
                        Console.WriteLine($"Parabéns, {jogador.Nome}! Você pescou um peixe na posição {tentativa}.");
                        jogador.Peixes++;
                        lago.Remove(tentativa);
                    }
                    else
                    {
                        Console.WriteLine($"{jogador.Nome}, posição sem peixe!");
                    }
                    jogador.Iscas--;
                }
            }
        }

        Console.WriteLine("Jogo terminado!");
        foreach (var jogador in jogadores)
        {
            Console.WriteLine($"{jogador.Nome} pescou {jogador.Peixes} peixe(s).");
        }

        var maxPeixes = Math.Max(0, jogadores.Max(j => j.Peixes));
        var vencedores = jogadores.FindAll(j => j.Peixes == maxPeixes);

        if (vencedores.Count > 1)
        {
            Console.WriteLine("Houve um empate! Vencedores:");
            foreach (var vencedor in vencedores)
            {
                Console.WriteLine($"- {vencedor.Nome}");
            }
        }
        else
        {
            Console.WriteLine($"O vencedor é {vencedores[0].Nome} com {vencedores[0].Peixes} peixe(s)!");
        }
    }
}

class Jogador
{
    public string Nome { get; set; }
    public int Iscas { get; set; }
    public int Peixes { get; set; }
}