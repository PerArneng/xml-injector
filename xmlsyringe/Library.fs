namespace XmlSyringe

open System.Text
open System.Xml.Linq
open System.Xml
open System.Xml.XPath

module Xml =

   
    let injectElementInXDocument (document:XDocument) (where:string) (xml:string):unit =
        
        let xElement = XElement.Parse(xml)
        let elements = document.XPathSelectElements(where)
        elements
            |> Seq.iter (printfn "%A")
        printfn ""

    let injectInXmlString (document:string) (where:string) (xml:string):string =
        let doc = (XDocument.Parse(document))
        injectElementInXDocument doc where xml

        let sb = new StringBuilder()

        let xws = new XmlWriterSettings() 
        xws.OmitXmlDeclaration <- true 
        xws.Indent <- true 
        
        use xw = (XmlWriter.Create(sb, xws))
        doc.Save(xw)
        xw.Flush()
        sb.ToString()
