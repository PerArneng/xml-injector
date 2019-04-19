namespace XmlSyringe

open NUnit.Framework

[<TestClass>]
type TestClass () =

    [<SetUp>]
    member this.Setup () =
        ()

    [<Test>]
    member this.Test1 () =

        let value = XmlSyringe.Xml.injectInXmlString "<h></h>" "//h" "<b></b>"

        Assert.AreEqual("<h></h>", value);

