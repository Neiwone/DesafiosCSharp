using System.Drawing;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Poligono
{
    public Vertice[] vertices;

    public int Vertices
    {
        get { return vertices.Length; }
    }

    public double Perimetro()
    {
        var sum = 0.0d;
        int i = 1;
        for (i = 1; i < Vertices; i++)
        {
            sum += vertices[i - 1].Distancia(vertices[i]);
        }
        sum += vertices[i-1].Distancia(vertices[0]);

        return sum;
    }

    

    public Poligono(Vertice[] vertices)
    {
        if (vertices.Length < 3)
        {
            throw new Exception("Erro criando poligono\nQuantidade de vertices insuficiente.");
        }

        this.vertices = vertices;
    }

    public bool AddVertice(Vertice v)
    {
        if (Array.Exists(vertices, ver => ver == v))
        {
            return false;
        }

        vertices = vertices.Append(v).ToArray(); 
        return true;
    }

    public void RemoveVertice(Vertice v)
    {
        if (!Array.Exists(vertices, ver => ver == v))
        {
            throw new Exception("Erro tentando remover vertice\nVertice v nao pertence ao poligono");
        }

        if (this.Vertices == 3)
        {
            throw new Exception("Erro tentando remover vertice\nNao e possivel remover mais vertices");
        }

        vertices = vertices.Where(ver => ver != v).ToArray();
    }


}

class Program
{
    static void Main(string[] args)
    {
        Vertice a = new Vertice(0, 0);
        Vertice b = new Vertice(0, 1);
        Vertice c = new Vertice(1, 0);

        Poligono p = new Poligono([a, b, c]);
        Console.WriteLine(p.Perimetro());

        Vertice d = new Vertice(-0.5, 0.5);
        Console.WriteLine(p.Vertices);
        Console.WriteLine(p.AddVertice(d));

        Console.WriteLine(p.Vertices);
        Console.WriteLine(p.Perimetro());

    }
}