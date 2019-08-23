using System;                           // INCOMPLETE - Refer to MSmith.vd082319.p2
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Partner p1 = new Partner();
            p1.VendorID = 123;
            p1.CreditLimit = 1000m;

            PrintLabel(p1);

            Customerc1 = new Customer();

            PrintLabel(c1);     // wont work, must implement an Interface



            Partner p2 = new Partner();
            p2.VendorID = 123;
            p2.CreditLimit = 5000m;

            if (p1.CompareTo(p2)>)
            {
                Console.WriteLine("p1 is better");
            }
            else
            {
                Console.WriteLine("p1 is not better");
            }

        }
        static void PrintLabel(IPrintLabel theAddressObject)
        {
            Console.WriteLine(theAddressObject.Name +" " +theAddressObject.Address);    
        }
    }

    interface IVendor           // USE OF INTERFACE TO MAKE A CONTRACT
    {
        int VendorID { get; set; }
        string Name { get; set; }
        decimal CreditLimit { get; set; }        // read-only property

        void YellAtVendor(string Msg);      // VOID - nothing returned
        string Purchase(string Item, int Qty);

        // EVENTS


    }

    interface IPrintLabel           // name should be an action
    {
       string Name { get; set; }          // Interface props are automatically public - don't have to type 'public'
       string Address { get; set; }
    }

    class Customer : IPrintLabel            // USE OF INTERFACE TO MAKE A CONNECTION
    {
        public int CustomerID { get; set; }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    //public int CustomerID { get; set; }
    //    public string Name { get; set; }
    //}
    class Partner : IVendor, IComparable, IPrintLabel
    {
    
        public int VendorID { get; /* => throw new NotImplementedException();*/ set; /* => throw new NotImplementedException(); */}
        public string Name { get /*=> throw new NotImplementedException() */; set /*=> throw new NotImplementedException()*/; }
        public string Address { get; set; }
        public decimal CreditLimit => throw new NotImplementedException();

        public int CompareTo(object obj)            // this is the only method implemented with IComparable // says we must accebt object so create Partner obj
        {            //  ((Partner)obj)  refer to boxing and unboxing later

            Partner theOtherGuy = (Partner)obj;
            if (this.CreditLimit == theOtherGuy.CreditLimit)        
            {
                return 0;
            }                                       // formal way to code if statements
            else
            {
                if (this.CreditLimit > theOtherGuy.CreditLimit)
                {
                    return 1;
                }
            }
            else
            {
                return -1;
            }
            throw new NotImplementedException();
        }

        public string Purchase(string Item, int Qty)
        {
            return "ok";            //throw new NotImplementedException();
        }

        public void YellAtVendor(string Msg)
        {
            //throw new NotImplementedException();
        }

                    //public int VendorID  { get; set; }                // first attempt, then used auto generated fix (above)

                    //public string Purchase(string Item, int Qty)
                    //{
                    //    return "purchased";

                    //}
    }

    class BankAccount
    {
        public int fred;
    }
}
