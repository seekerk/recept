using System.ComponentModel;
namespace Recept2
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Text;
	using System.Windows.Forms;
	using System.Xml;
	using System.Xml.XPath;
	
	public class DataMicroBiologyIndicator : DataBase
	{
	    /// <summary>
	    /// Значение показателя микробиологии.
	    /// </summary>
	    private string myQuantity;
	    
	    /// <summary>
	    /// Значение показателя микробиологии.
	    /// </summary>
	    public new string Quantity
	    {
	        get {
	            return myQuantity;
	        }
	        
	        set {
	            myQuantity = value;
	        }
	    }
	    
	    public override XmlNode StoreToXml(XmlDocument doc, string nodeName)
	    {
	        XmlNode root = doc.CreateElement(nodeName);
	        XmlNode curNode = root.AppendChild(doc.CreateElement("name"));
	        curNode.InnerText = this.Name;
	        curNode = root.AppendChild(doc.CreateElement("quantity"));
	        curNode.InnerText = this.Quantity;
	        curNode = root.AppendChild(doc.CreateElement("comment"));
	        curNode.InnerText = this.Comment;
	
	        return root;
	    }
	    
	    public static DataMicroBiologyIndicator LoadFromXml(XmlNode root, DataBase parent, ReceptVersion ver)
	    {
	        throw new NotImplementedException();
	    }
	    
	    public override decimal PercentFilling()
	    {
	        throw new NotImplementedException();
	    }
	}
}
