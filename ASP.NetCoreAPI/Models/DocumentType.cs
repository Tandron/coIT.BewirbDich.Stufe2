namespace ASP.NetCoreAPI.Models
{
    public enum DocumentType  // Eigentlich sollte der Quellcode in englisch umgestellt werden. Da es international werden sollte. 
    {
        Offer,            // = 1, TODO wozu? Rechner fangen mit einer 0 an
        InsurancePolicy   // = 2 und hier auch unnötig, wenn ich bei der vorrigen Zeile = 1 schreibe brauche ich hier nichts machen.
                          // da es immer plus 1 hochgezählt wird in einem enum
    }
}
