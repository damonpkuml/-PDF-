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

namespace 第二章_块语句和段落_ {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// chunk基本使用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e) {
            Document document = new Document();
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream("chunk基本使用.pdf", FileMode.Create));
            document.Open();

            //创建"Helo world" ,红色,斜体,Courier字体,尺寸20的一个块
            Chunk chunk = new Chunk("Hello Chunk", FontFactory.GetFont(FontFactory.COURIER, 20, Font.ITALIC,
               BaseColor.RED));

            //背景设置为绿色
            chunk.SetBackground(BaseColor.GREEN);

            document.Add(chunk);

            document.Close();
            this.Title = "块的基本使用";
        }


        /// <summary>
        /// chunk字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Document document = new Document();
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream("chunk 字体.pdf", FileMode.Create));
            document.Open();

            //创建"Helo world" ,红色,斜体,Courier字体,尺寸20的一个块
            Chunk chunk = new Chunk("Bold", FontFactory.GetFont(FontFactory.COURIER, 20, Font.BOLD,
                BaseColor.RED));

            document.Add(chunk);

            document.Close();
            this.Title = "字体";
        }

        //下划线
        private void Button_Click_2(object sender, RoutedEventArgs e) {
            Document document = new Document();
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream("chunk 下划线.pdf", FileMode.Create));
            document.Open();

            //创建"Helo world" ,红色,斜体,Courier字体,尺寸20的一个块
            Chunk chunk = new Chunk("UnderLine", FontFactory.GetFont(FontFactory.COURIER, 20, Font.UNDERLINE));

            document.Add(chunk);

            //添加另外一个chunk,默认字体样式
            Chunk chunk2 = new Chunk("Second Chunk", FontFactory.GetFont(FontFactory.COURIER, 12));
            document.Add(chunk2);
            
            //划线和上标
            Chunk chunkDelete=new Chunk("Delete content",FontFactory.GetFont(FontFactory.COURIER,12,Font.STRIKETHRU));
            chunkDelete.SetTextRise(3);
            document.Add(chunkDelete);
            
            document.Close();
            this.Title = "下划线"+"字体默认值大小:"+Font.DEFAULTSIZE;
        }

        //说明：一个段落有一个且仅有一个间距，如果你添加了一个不同字体的短句或块，
        //原来的间距仍然有效，你可以通过SetLeading来改变间距，
        //但是段落中所有内容将使用新的中的间距
        private void Button_Click_3(object sender, RoutedEventArgs e) {
            Document document = new Document();
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream("段落.pdf", FileMode.Create));
            document.Open();
            Paragraph p1=new Paragraph(new Chunk("This is the fist paragraph",
                FontFactory.GetFont(FontFactory.HELVETICA,12)));
            
            //段落中插入chunk
            Chunk ck1=new Chunk("Test chunk eea fafafe fafeefaeefefeafaefafafaeeea fafafe fafeefaeefefeafae", FontFactory.GetFont(FontFactory.COURIER,
                20,BaseColor.BLUE));
            p1.Add(ck1);
            p1.SetLeading(10,1);

            Paragraph p2 = new Paragraph(new Phrase("This is the second paragraph",
                FontFactory.GetFont(FontFactory.HELVETICA,12)));

            Paragraph p3 = new Paragraph("This is the third paragraph",
                FontFactory.GetFont(FontFactory.HELVETICA,12));

            document.Add(p1);
            document.Add(p2);
            document.Add(p3);

            document.Close();
            this.Title = "段落";
        }
    }
}
