﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Model
{
    [Serializable]
    public enum StatusUgrozenosti
    {
        KriticnoUgrozena,
        Ugrozena,
        Ranjiva,
        ZavisnaOdOcuvanjaStanista,
        BlizuRizika,
        NajmanjegRizika
    }
}