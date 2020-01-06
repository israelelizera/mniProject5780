using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    /// <summary>
    /// this class represent a host with some hosting unit
    /// </summary>
    public class Host
    {
        public int HostKey;
        public string PrivateName;
        public string FamilyName;
        public int FhoneNumber;
        public string MailAddress;
        public BankAccount BankAccount;
        public bool CollectionClearance;//Certificate of collection from the bank account
        public List<HostingUnit> hostingUnits;

        public override string ToString() { return null; }
        public int getHostKey() { return HostKey; }
    }
}
