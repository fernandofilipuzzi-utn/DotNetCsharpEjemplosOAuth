using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2_0Models.Models
{
    public class ClienteCredencial
    {
        public int Id { get; set; }
        public string Client_ID { get; set; }
        public string Client_Secret { get; set; }        
    }
}
