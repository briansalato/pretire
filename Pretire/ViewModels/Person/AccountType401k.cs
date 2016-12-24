using System.ComponentModel.DataAnnotations;

namespace Pretire.ViewModels.Person
{
    public enum AccountType401k
    {
        [Display(Name = "No 401k")] None,
        [Display(Name = "Traditional")] Traditional,
        [Display(Name = "Roth")] Roth
    }
}