public class Vertice
{
    private double _x, _y;
    public double X 
    { 
        get { return _x; } 
        private set { _x = value; }
    }
    public double Y
    {
        get { return _y; }
        private set { _y = value; }
    }

    public Vertice(double X, double Y)
    {
        this.X = X;
        this.Y = Y;
    }

    public double Distancia(Vertice v)
    {
        return Math.Sqrt(Math.Pow(v.X - this.X, 2) + Math.Pow(v.Y - this.Y, 2));
    }

    public void Move(double newX, double newY)
    {
        this.X = newX;
        this.Y = newY;
    }

    public static bool operator ==(Vertice v, Vertice w)
    {
        return (v.X == w.X) && (v.Y == w.Y);
    }

    public static bool operator !=(Vertice v, Vertice w)
    {
        return (v.X != w.X) || (v.Y != w.Y);
    }

    public override bool Equals(object v)
    {
        if (v.GetType() != this.GetType()) return false;

        return this == (Vertice) v;
    }

    public static bool CheckAlignment(Vertice A, Vertice B, Vertice C)
    {
        var maindiagonal = A.X * B.Y + A.Y * C.X + B.X * C.Y;
        var antidiagonal = C.X * B.Y + C.Y * A.X + B.X * A.Y;

        return (maindiagonal - antidiagonal) == 0;
    }

}

class Program
{
    static void Main(string[] args)
    {
        Vertice U = new Vertice(0, 0);
        Vertice V = new Vertice(1, 1);
        Console.WriteLine("Distancia de U a V: " + U.Distancia(V) + '\n');

        Console.WriteLine("U é igual a V? " + (U == V).ToString() + '\n');

        Console.WriteLine("Mudando coordenadas de U...\n");
        U.Move(1, 1);

        Console.WriteLine("Distancia de U a V: " + U.Distancia(V) + '\n');

        Console.WriteLine("U é igual a V? " + (U == V).ToString() + '\n');

    }
}