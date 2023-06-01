using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//using iText.Kernel.Pdf;
//using iText.Kernel.Font;
//using iText.Layout.Element;
//using iText.Layout.Properties;
//using iText.Layout;


public class PDF
{
    public void Create(string name)
    {
        string path = Application.dataPath + string.Format("/{0}.pdf", name);
        Debug.Log(path);
        /*
        PdfWriter pdfWriter = new PdfWriter(path);
        PdfDocument pdfDocument = new PdfDocument(pdfWriter);
        Document document = new Document(pdfDocument);
        float[] columnWidth = { 200, 300 };
        Table table1 = new Table(columnWidth);


        table1.AddCell(new Cell(3, 1).SetHeight(75).Add(new Paragraph("TOP BETON").SetFontSize(14)).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        document.Add(table1);
        document.Close();       
        */
    }
}
