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
using List = iTextSharp.text.List;
using ListItem = iTextSharp.text.ListItem;
using Paragraph = iTextSharp.text.Paragraph;

namespace 第三章_锚点_列表_注释_ {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        //使用列表
        private void Button_Click(object sender, RoutedEventArgs e) {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("列表.pdf", FileMode.Create));

            document.Open();
            //第一个参数表示是否排序
            List list = new List(true, 20);
            list.Add(new ListItem("First line."));
            list.Add(new ListItem(
                "The second line is longer to see what happens once the end of the line is reached.Will it start on a new line"));
            list.Add(new ListItem(20,"Third Line."));
            document.Add(list);

            Paragraph p1 = new Paragraph(new Phrase("Test paragraph"));
            document.Add(p1);

            //无序列表
            List unsortedList = new List(false, 10);
            unsortedList.Add(new ListItem("This is an item"));
            unsortedList.Add("Another item");
            document.Add(unsortedList);

            //更改列表符号
            List symbolList = new List(true);
            symbolList.ListSymbol = new Chunk("*");
            symbolList.Add(new ListItem("Test1"));
            symbolList.Add(new ListItem("Test1"));
            symbolList.Add(new ListItem("Test3"));
            document.Add(symbolList);
            document.Close();

            Title = "使用列表";
        }

        //使用注释
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           //Annotation annotation=new Annotation(0,0,0,0,"test.pdf",3);
        }
    }
}
