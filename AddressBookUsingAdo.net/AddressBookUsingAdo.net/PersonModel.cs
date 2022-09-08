using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAdo.net;

public class PersonModel
{
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Zip { get; set; }
    public int Phone_Num { get; set; }
    public string Email { get; set; }
    public string Type { get; set; }
}