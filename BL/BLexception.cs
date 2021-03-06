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

        public class InvalidPrivateNameException : Exception
        {
            public InvalidPrivateNameException() { }
        }

        public class InvalidFamilyNameException : Exception
        {
            public InvalidFamilyNameException() { }
        }

        public class InvalidMailAddressEception : Exception
        {
            public InvalidMailAddressEception() { }
        }

        public class InvalidNumberVacationersException : Exception
        {
            public InvalidNumberVacationersException() { }
        }

        public class InvalidHostingUnitNameException : Exception
        {
            public InvalidHostingUnitNameException() { }
        }

        public class DiaryIsNullException : Exception
        {
            public DiaryIsNullException() { }
        }

        public class DayCantBeUnderZeroException : Exception
        {
            public DayCantBeUnderZeroException() { }
        }

        public class OpenOrderException : Exception
        {
            public OpenOrderException() { }
        }

        public class CloseOrderException : Exception
        {
            public CloseOrderException() { }
        }

        public class UnvailableHostingUnitException : Exception
        {
            public UnvailableHostingUnitException() { }
        }

        public class HostingUnitDoesntExistException : Exception
        {
            public HostingUnitDoesntExistException() { }
        }
        public class GuestRequestDoesntExistException : Exception
        {
            public GuestRequestDoesntExistException() { }
        }

        public class InvalidCapacityException : Exception
        {
            public InvalidCapacityException() { }
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