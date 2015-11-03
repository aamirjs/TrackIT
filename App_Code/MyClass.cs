using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;


public interface IAamir
{
    void SayHello();
}

public class Aamir : IAamir
{
    public void SayHello()
    {
        ;
    }
}


public class MyClass
{
    public MyClass()
    {

        var a = new Aamir();
        a.SayHello();

        //
        // TODO: Add constructor logic here
        //
    }
}
