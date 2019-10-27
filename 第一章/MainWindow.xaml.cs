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
using Rectangle = iTextSharp.text.Rectangle;

namespace 第一章 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void GeneratePdf() {
            //创建一个文档,默认使用A4大小: 595f, 842f
            Document document = new Document();

            //关联文件流
            PdfWriter.GetInstance(document, new FileStream("第一个.pdf", FileMode.Create));

            //打开文档
            document.Open();

            //添加一段文本
            document.Add(new Paragraph("hello itextssharp"));

            //关闭
            document.Close();

        }

        /// <summary>
        /// 设置背景
        /// </summary>
        private void PdfBackground() {
            Rectangle rectangle = new Rectangle(595f, 842f);
            rectangle.BackgroundColor = BaseColor.RED;
            Document document = new Document(rectangle);

            PdfWriter.GetInstance(document, new FileStream("设置背景.pdf", FileMode.Create));
            document.Open();
            document.Add(new Paragraph("设置背景"));

            document.Close();
        }


        /// <summary>
        /// 设置边距
        /// </summary>
        private void SetMargin()
        {
            Rectangle rectangle = new Rectangle(144, 720);
            rectangle.BackgroundColor=BaseColor.BLUE;
            Document document = new Document(rectangle, 36, 72, 108, 180);

            var pdfWriter = PdfWriter.GetInstance(document, new FileStream("设置边距.pdf", FileMode.Create));
            
            document.Open();
            document.Add(new Paragraph("设置边距"));

            document.Close();
        }

        private void 基本使用(object sender, RoutedEventArgs e) {
            GeneratePdf();
            this.Title = "基本使用";
        }

        private void 设置背景(object sender, RoutedEventArgs e) {
            PdfBackground();
            Title = "设置背景";
        }

        private void 设置页面间距(object sender, RoutedEventArgs e)
        {
            SetMargin();
            Title = "设置页面间距";
        }

        private void 添加摘要(object sender, RoutedEventArgs e)
        {
            //todo:
            Title = "添加摘要";
        }
    }
}
