using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace 页眉页脚
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected void pdfBt_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4);
            System.IO.FileStream file =
                new System.IO.FileStream( DateTime.Now.ToString("ddMMyyHHmmss") + ".pdf",
                System.IO.FileMode.OpenOrCreate);
            PdfWriter writer = PdfWriter.GetInstance(doc, file);
            // calling PDFFooter class to Include in document

            writer.PageEvent = new PDFFooter();
            doc.Open();
            PdfPTable tab = new PdfPTable(3);
            PdfPCell cell = new PdfPCell(new Phrase("Header",
                                new Font(Font.FontFamily.HELVETICA, 24F)));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                                          //Style
            cell.BorderColor =BaseColor.RED;
            cell.Border = Rectangle.BOTTOM_BORDER; // | Rectangle.TOP_BORDER;
            cell.BorderWidthBottom = 3f;
            tab.AddCell(cell);
            //row 1
            tab.AddCell("R1C1");
            tab.AddCell("R1C2");
            tab.AddCell("R1C3");
            //row 2
            tab.AddCell("R2C1");
            tab.AddCell("R2C2");
            tab.AddCell("R2C3");

            //无序列表，占三列
            cell = new PdfPCell();
            cell.Colspan = 3;
            iTextSharp.text.List pdfList = new List(List.UNORDERED);
            pdfList.Add(new iTextSharp.text.ListItem(new Phrase("Unorder List 1")));
            pdfList.Add("Unorder List 2");
            pdfList.Add("Unorder List 3");
            pdfList.Add("Unorder List 4");
            cell.AddElement(pdfList);
            tab.AddCell(cell);
            doc.Add(tab);
            doc.Close();
            file.Close();
        }

        public class PDFFooter : PdfPageEventHelper
        {
            // write on top of document
            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                base.OnOpenDocument(writer, document);
                //PdfPTable tabFot = new PdfPTable(new float[] { 1F });
                //tabFot.SpacingAfter = 10F;
                //PdfPCell cell;
                //tabFot.TotalWidth = 300F;
                //cell = new PdfPCell(new Phrase("Header"));
                //tabFot.AddCell(cell);
                //tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);
            }

            // write on start of each page
            public override void OnStartPage(PdfWriter writer, Document document)
            {
                base.OnStartPage(writer, document);
            }

            // write on end of each page
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);
                PdfPTable tabFot = new PdfPTable(new float[] { 1F });
                PdfPCell cell;
                tabFot.TotalWidth = 300F;
                cell = new PdfPCell(new Phrase("Footer"));
                tabFot.AddCell(cell);
                tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);
           
            }

            //write on close of document
            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                base.OnCloseDocument(writer, document);
            }
        }
    }
}
