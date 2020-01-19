using System;
using System.Collections.Generic;
using System.Text;
namespace DAL
{

    public class dalExeptionIDalreadyExist : Exception
    {
        public dalExeptionIDalreadyExist() { }

    }
    public class dalExeptionItemDoesntExist:Exception
    {
        public dalExeptionItemDoesntExist() {}
    }
    public class dalExeptionMoreThanOneAnswer : Exception
    {
        public dalExeptionMoreThanOneAnswer() { }
    }
}