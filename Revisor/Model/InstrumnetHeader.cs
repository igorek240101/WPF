﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AticaRevisorPcManager.Model
{
    public class InstrumnetHeader
    {
        public int Id { get; set; }
        public string XKey { get; set; }
        public InstrumentNomenclature Nomenclature { get; set; }
 
    }
}
