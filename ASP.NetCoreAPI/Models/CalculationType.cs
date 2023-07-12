namespace ASP.NetCoreAPI.Models
{
    public enum CalculationType
    {
        TurnOver,       // Umsatz    = 1, ist nur notwendig, wenn man ab 1 den enum nutzen will, in dem Fall machen wir es mal nicht.
        BudgetarySum,       // Haushaltssumme
        CountEmployees      // Anzahl der Mitarbeiter
    }
}
