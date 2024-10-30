public class Intervalo
{
    public DateTime Inicial
    {
        private set;
        get;
    }
    public DateTime Final
    {
        private set;
        get;
    }

    public TimeSpan Duracao => Final - Inicial;

    public Intervalo(DateTime inicial, DateTime final)
    {
        if (inicial > final)
        {
            throw new Exception("Erro tentando criar Intervalo\ndata final antes da data inicial");
        }

        Inicial = inicial;
        Final = final;
    }

    public bool TemIntersecao(Intervalo i)
    {
        return (i.Inicial <= Final) && (Final <= i.Final) || (i.Inicial <= Inicial) && (Inicial <= i.Final);
    }

    public static bool operator ==(Intervalo a, Intervalo b)
    {
        return (a.Inicial == b.Inicial) && (a.Final == b.Final);
    }

    public static bool operator !=(Intervalo a, Intervalo b)
    {
        return (a.Inicial != b.Inicial) || (a.Final != b.Final);
    }
}