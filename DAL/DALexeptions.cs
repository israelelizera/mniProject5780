using System;
using System.Collections.Generic;
using System.Text;
namespace DAL
{

    public class dalExeptionIDalreadyExist : Exception
    {
        public dalExeptionIDalreadyExist() { }

    }
    public class dalExeptionItemDoesntexist:Exception
    {
        public dalExeptionItemDoesntexist() {}
    }
    public class dalExeptionMoreThanOneAnswer : Exception
    {
        public dalExeptionMoreThanOneAnswer() { }
    }
}