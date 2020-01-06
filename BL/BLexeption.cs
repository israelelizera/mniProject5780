using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class BLexception
    {
        public class InvalidDatesException : Exception
        {
            public InvalidDatesException() { }
        }

        public class PrivateNameMissingException : Exception
        {
            public PrivateNameMissingException() { }
        }
        public class FamilyNameMissingException : Exception
        {
            public FamilyNameMissingException() { }
        }

        public class InvalidMailAddressEception : Exception
        {
            public InvalidMailAddressEception() { }
        }
        public class InvalidNumberVacationersException : Exception
        {
            public InvalidNumberVacationersException() { }
        }
        public class HostingUnitNameMissingException : Exception
        {
            public HostingUnitNameMissingException() { }
        }
        public class DiaryIsNullException : Exception
        {
            public DiaryIsNullException() { }
        }

        public class CantUndeZeroException : Exception
        {
            public CantUndeZeroException() { }
        }
        public class OpenOrderException : Exception
        {
            public OpenOrderException() { }
        }

        public class CloseOrderException : Exception
        {
            public CloseOrderException() { }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}