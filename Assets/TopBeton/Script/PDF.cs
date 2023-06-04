using System.Collections;
using UnityEngine;
using System.IO;

public class PDF : MonoBehaviour
{
    [SerializeField] private string _path = null;
    [SerializeField] private UnityEngine.UI.Text _text1;
    [SerializeField] private UnityEngine.UI.Text _text2;
    [SerializeField] private UnityEngine.UI.Text _date;
    [SerializeField] private UnityEngine.UI.Text _number;
    [SerializeField] private UnityEngine.UI.Text _driver;
    [SerializeField] private UnityEngine.UI.Text _speedMor;
    [SerializeField] private UnityEngine.UI.Text _speedEv;
    [SerializeField] private UnityEngine.UI.Text _fuel;

    [SerializeField] private UnityEngine.UI.Text _dir1;
    [SerializeField] private UnityEngine.UI.Text _prod1;
    [SerializeField] private UnityEngine.UI.Text _am1;

    [SerializeField] private UnityEngine.UI.Text _dir2;
    [SerializeField] private UnityEngine.UI.Text _prod2;
    [SerializeField] private UnityEngine.UI.Text _am2;

    [SerializeField] private UnityEngine.UI.Text _dir3;
    [SerializeField] private UnityEngine.UI.Text _prod3;
    [SerializeField] private UnityEngine.UI.Text _am3;

    [SerializeField] private UnityEngine.UI.Text _dir4;
    [SerializeField] private UnityEngine.UI.Text _prod4;
    [SerializeField] private UnityEngine.UI.Text _am4;

    [SerializeField] private UnityEngine.UI.Text _dir5;
    [SerializeField] private UnityEngine.UI.Text _prod5;
    [SerializeField] private UnityEngine.UI.Text _am5;

    [SerializeField] private UnityEngine.UI.Text _dir6;
    [SerializeField] private UnityEngine.UI.Text _prod6;
    [SerializeField] private UnityEngine.UI.Text _am6;

    [SerializeField] private UnityEngine.UI.Text _dir7;
    [SerializeField] private UnityEngine.UI.Text _prod7;
    [SerializeField] private UnityEngine.UI.Text _am7;

    [SerializeField] private UnityEngine.UI.Text _dir8;
    [SerializeField] private UnityEngine.UI.Text _prod8;
    [SerializeField] private UnityEngine.UI.Text _am8;

    public void GenerateFile()
    {
        /*
        _path = Application.persistentDataPath + string.Format("/{0}({1}).pdf", _number.text, _date.text);
        Debug.Log(_path);
        if (File.Exists(_path))
            File.Delete(_path);

        //FileStream fileStream = new(_path, FileMode.Create, FileAccess.ReadWrite);
        PdfWriter pdfWriter = new PdfWriter(_path, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0));
        PdfDocument pdfDocument = new(pdfWriter);
        Document document = new(pdfDocument, iText.Kernel.Geom.PageSize.A4);

        string FONT = Path.Combine(Application.dataPath, @"StreamingAssets/TNR.ttf");
        PdfFont font = PdfFontFactory.CreateFont(FONT, "Cp1251");
        document.SetFont(font);

        Paragraph p = new Paragraph(string.Format("Ticket Id АБВ : {0}", 12345));
        document.Add(p);

        
        float[] columnWidth = { 200, 300 };
        Table table = new Table(columnWidth);
        table.AddCell(new Cell(3, 1).SetHeight(75).Add(new Paragraph("ООО ПСК \"ТОП БЕТОН\"").SetFontSize(14)).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell(2, 1).SetHeight(50).Add(new Paragraph("ПУТЕВОЙ ЛИСТ ВОДИТЕЛЮ").SetFontSize(14)).SetBorder(Border.NO_BORDER).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph(string.Format("Дата: {0}", _date.text))).SetFontSize(12).SetBorder(Border.NO_BORDER).SetBold().SetVerticalAlignment(VerticalAlignment.BOTTOM));

        table.AddCell(new Cell().Add(new Paragraph("Гос. номерной знак:").SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)));
        table.AddCell(new Cell().Add(new Paragraph(_number.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE)));

        table.AddCell(new Cell().Add(new Paragraph("Водитель:").SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)));
        table.AddCell(new Cell().Add(new Paragraph(_driver.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE)));

        table.AddCell(new Cell().SetHeight(25).Add(new Paragraph("Работа автомобиля:").SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)).SetVerticalAlignment(VerticalAlignment.BOTTOM));
        table.AddCell(new Cell().SetHeight(25).Add(new Paragraph("")).SetBorder(Border.NO_BORDER));

        table.AddCell(new Cell().Add(new Paragraph("Показание спидометра (км) - утро").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_speedMor.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Показание спидометра (км) - вечер").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_speedEv.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().SetHeight(25).Add(new Paragraph("Движение горючего: ДТ").SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)).SetVerticalAlignment(VerticalAlignment.BOTTOM));
        table.AddCell(new Cell().SetHeight(25).Add(new Paragraph("")).SetBorder(Border.NO_BORDER));

        table.AddCell(new Cell().Add(new Paragraph("Выдано, л:").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_fuel.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().SetHeight(25).Add(new Paragraph("Маршрут:").SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.BOTTOM));
        table.AddCell(new Cell().SetHeight(25).Add(new Paragraph("")).SetBorder(Border.NO_BORDER));

        //Маршрут 1
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph("Откуда-куда").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph(_dir1.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Продукция").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_prod1.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Количество (тн, м3)").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_am1.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        //Маршрут 2
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph("Откуда-куда").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph(_dir2.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Продукция").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_prod2.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Количество (тн, м3)").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_am2.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        //Маршрут 3
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph("Откуда-куда").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph(_dir3.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Продукция").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_prod3.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Количество (тн, м3)").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_am3.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        //Маршрут 4
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph("Откуда-куда").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph(_dir4.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Продукция").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_prod4.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Количество (тн, м3)").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_am4.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        //Маршрут 5
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph("Откуда-куда").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph(_dir5.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Продукция").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_prod5.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Количество (тн, м3)").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_am5.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        //Маршрут 6
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph("Откуда-куда").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph(_dir6.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Продукция").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_prod6.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Количество (тн, м3)").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_am6.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        //Маршрут 7
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph("Откуда-куда").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph(_dir7.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Продукция").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_prod7.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Количество (тн, м3)").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_am7.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        //Маршрут 8
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph("Откуда-куда").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().SetHeight(30).Add(new Paragraph(_dir8.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Продукция").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_prod8.text).SetFontSize(12).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        table.AddCell(new Cell().Add(new Paragraph("Количество (тн, м3)").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)).SetVerticalAlignment(VerticalAlignment.MIDDLE));
        table.AddCell(new Cell().Add(new Paragraph(_am8.text).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetVerticalAlignment(VerticalAlignment.MIDDLE));

        document.Add(table);
        
        document.Close();
        pdfDocument.Close();
        */
    }

    private IEnumerator Share()
    {
        yield return new WaitForEndOfFrame();
        new NativeShare().AddFile(_path)
        .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
        .Share();

    }
}
