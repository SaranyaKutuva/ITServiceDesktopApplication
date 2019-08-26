using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServices.Model
{
    class Payment
    {
        private DataRow dr;

        public Payment(DataRow dr)
        {
            this.dr = dr;
        }
    }
}
