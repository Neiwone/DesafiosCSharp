class ListaIntervalo
{
    private List<Intervalo> _intervalos;

    public List<Intervalo> Intervalos => _intervalos.OrderBy(i => i.Inicial).ToList();

    public bool Add(Intervalo i)
    {
        if (_intervalos.Any(intervalo => intervalo.TemIntersecao(i)))
        {
            return false;
        }

        _intervalos.Add(i);
        return true;
    }
}