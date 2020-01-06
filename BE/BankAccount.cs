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
        int BankNumber;
        string BankName;
        int BranchNumber;
        string BranchAddress;
        string BranchCity;
        int BankAccountNumber;
        public override string ToString() { return null; }

        BankAccount(int bankNumber, string bankName, int branchNumber,
            string branchAddress,string branchCity,int bankAccountNumber)
        {
            BankNumber = bankNumber;
            BankName = bankName;
            BranchAddress = branchAddress;
            BranchNumber = branchNumber;
            BranchCity = branchCity;
            BankAccountNumber = bankAccountNumber;
        }
    }
}
