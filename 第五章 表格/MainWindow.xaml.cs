using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Paragraph = iTextSharp.text.Paragraph;

namespace 第五章_表格 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        //简单表格使用
        private void Button_Click(object sender, RoutedEventArgs e) {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("表格简单使用.pdf",
                FileMode.OpenOrCreate));
            document.Open();

            PdfPTable table = new PdfPTable(3);
            table.AddCell("1");
            table.AddCell("2");
            table.AddCell("3");
            table.AddCell("4");

            //table的基本方法
            PdfPCell cell1 = new PdfPCell(new Phrase("Cell1"));
            cell1.Colspan = 2;
            table.AddCell(cell1);

            table.AddCell("4");
            table.AddCell("5");
            table.AddCell("6");
            table.AddCell("7");
            table.AddCell("8");
            table.AddCell("9");  //最后行,必须有三列才显式,如果注释此行,前面的7,8都不会显式

            //不起作用?
            //cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell1.BackgroundColor=BaseColor.GREEN;

            Paragraph p1 = new Paragraph();
            p1.Add(table);

            document.Add(p1);

            document.Close();
            Title = "简单表格使用";
        }
    }
}
