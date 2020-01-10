using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    //yehuda
    /// <summary>
    /// this class represent a bank account of a client
    /// </summary>
    public class BankAccount
    {
       public int BankNumber;
       public string BankName;
        /// <summary>
        /// number of snif
        /// </summary>
        public int BranchNumber;
       public string BranchAddress;
       public string BranchCity;
        public override string ToString() { return null; }

        /*BankAccount(int bankNumber, string bankName, int branchNumber,
            string branchAddress, string branchCity, int bankAccountNumber)
        {
            BankNumber = bankNumber;
            BankName = bankName;
            BranchAddress = branchAddress;
            BranchNumber = branchNumber;
            BranchCity = branchCity;
            BankAccountNumber = bankAccountNumber;
        }*/
    }
}
