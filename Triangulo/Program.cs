class Triangulo
{
    public enum Type
    {
        EQUILATERO,
        ISOSCELES,
        ESCALENO
    }

    public Vertice A, B, C;

    public double Perimetro
    {
        get
        {
            return A.Distancia(B) + B.Distancia(C) + C.Distancia(A);
        }
    }

    public Type Tipo
    {
        get
        {
            if (A.Distancia(B) == B.Distancia(C) && B.Distancia(C) == C.Distancia(A))
            {
                return Type.EQUILATERO;
            }

            if (A.Distancia(B) == B.Distancia(C) || B.Distancia(C) == C.Distancia(A) || C.Distancia(A) == A.Distancia(B))
            {
                return Type.ISOSCELES;
            }

            return Type.ESCALENO;

        }
    }

    public double Area
    {
        get
        {
            var S = Perimetro / 2;
            var a = A.Distancia(B);
            var b = B.Distancia(C);
            var c = C.Distancia(A);

            var area = Math.Sqrt(S * (S - a) * (S - b) * (S - c));

            return area;
        }
    }

    public Triangulo(Vertice A, Vertice B, Vertice C)
    {
        if (A == B || B == C || A == C)
        {
            throw new Exception("Erro tentando criar triangulo\nOs vertices nao formam um triangulo");
        }

        if (Vertice.CheckAlignment(A, B, C))
        {
            throw new Exception("Erro tentando criar triangulo\nOs vertices nao formam um triangulo");
        }

        this.A = A;
        this.B = B;
        this.C = C;
    }

    public static bool operator ==(Triangulo v, Triangulo w)
    {
        return (v.A == w.A) && (v.B == w.B) && (v.C == w.C);
    }

    public static bool operator !=(Triangulo v, Triangulo w)
    {
        return (v.A != w.A) || (v.B != w.B) || (v.C != w.C);
    }

}

class Program
{
    static void Main(string[] args)
    {
        Vertice a = new Vertice(0, 0);
        Vertice b = new Vertice(0, 1);
        Vertice c = new Vertice(1, 0);

        Triangulo t = new Triangulo(a, b, c);
        Console.WriteLine(t.Area);
        Console.WriteLine(t.Perimetro);
        Console.WriteLine(t.Tipo);

        Triangulo t2 = new Triangulo(a, b, c);
        Console.WriteLine(t == t2);

    }
}