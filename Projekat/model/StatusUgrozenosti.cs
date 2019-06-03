using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projekat.Model
{
    [Serializable]
    public enum StatusUgrozenosti
    {
        [Display(Name ="Good Body")]
        KriticnoUgrozena,
        [Display(Name = "Good Body")]
        Ugrozena,
        [Display(Name = "Good Body")]
        Ranjiva,
        [Display(Name = "Good Body")]
        ZavisnaOdOcuvanjaStanista,
        [Display(Name = "Good Body")]
        BlizuRizika,
        [Display(Name = "Good Body")]
        NajmanjegRizika
    }
}
