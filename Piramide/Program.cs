class Program
{
    static void Main(string[] args)
    {
        Piramide piramideN1 = new Piramide(1);
        Console.WriteLine("Piramide de altura 1:");
        piramideN1.Desenha();

        Piramide piramideN4 = new Piramide(4);
        Console.WriteLine("Piramide de altura 4:");
        piramideN4.Desenha();

        Piramide piramideN7 = new Piramide(7);
        Console.WriteLine("Piramide de altura 7:");
        piramideN7.Desenha();

        Piramide piramideError = new Piramide(-10);
    }
}

class Piramide
{
    private int _n;
    public int N
    {
        get { return _n; }
        set
        {
            if (value < 1)
            {
                throw new Exception("Erro ao tentar criar Piramide\n-> Valor de N invalido (N < 1)");
            }
            else
            {
                _n = value;
            }
        }
    }

    public Piramide(int N)
    {
        this.N = N;
    }

    public void Desenha()
    {
        for (int i = 1; i <= N; i++)
        {
            // Printa N-i espacos
            for (int j = 0; j < N - i; j++)
            {
                Console.Write(' ');
            }
            // Sequencia crescendo 1->N
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j);
            }
            // Sequencia decrescendo N-1->1
            for (int j = i - 1; j >= 1; j--)
            {
                Console.Write(j);
            }
            // Printa N-i espacos
            for (int j = 0; j < N - i; j++)
            {
                Console.Write(' ');
            }
            Console.Write('\n');
        }
        Console.WriteLine();
    }
}