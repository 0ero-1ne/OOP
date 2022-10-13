using System;

namespace LabThree
{
    class Production
    {
        int ID;

        public string Company
        {
            get => company;
            set => company = value;
        }
        string company;

        public Production()
        {
            ID = GetHashCode();
            Company = "BSTU";
        }

        public Production(string company)
        {
            ID = GetHashCode();
            Company = company;
        }

        public void PrintInfo()
        {
            Console.WriteLine("ID - {0}\nCompany - {1}\n", ID, Company);
        }
    }
}
