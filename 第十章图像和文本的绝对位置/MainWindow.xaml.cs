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
using Section = iTextSharp.text.Section;

namespace 第十章图像和文本的绝对位置 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        //简单使用
        private void Button_Click(object sender, RoutedEventArgs e) {
            Document document=new Document();
            PdfWriter pdfWriter=PdfWriter.GetInstance(document,new FileStream("简单使用.pdf",
                FileMode.OpenOrCreate));
            document.Open();

            PdfContentByte cb = pdfWriter.DirectContent; //最上方

            //画线
            cb.SetLineWidth(2);
            cb.MoveTo(0,0);  //以当前页左下角为原点
            cb.LineTo(200,300);
            
            cb.Stroke();

            //在某个具体位置绘制文本
            BaseFont bf=BaseFont.CreateFont(BaseFont.HELVETICA,BaseFont.CP1252,
                BaseFont.NOT_EMBEDDED);
            cb.BeginText();
            cb.SetFontAndSize(bf,12);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT,"This text is centered",
                0,100,0);
            cb.EndText();

            //为了测试，添加3章
            for (int i = 0; i < 10; i++) {
                //章节的标题
                Paragraph cTitle = new Paragraph($"This is chapter {i}", FontFactory.GetFont(
                    FontFactory.COURIER, 18));
                Chapter chapter = new Chapter(cTitle, i);

                //如果是偶数章节书签默认不打开
                if (i % 2 == 0) {
                    chapter.BookmarkOpen = false;
                }

                //每章添加2个区域
                for (int j = 0; j < 60; j++) {
                    //子区域
                    Paragraph sTitle = new Paragraph($"This is section {j} in chapter {i}",
                        FontFactory.GetFont(FontFactory.COURIER, 12, BaseColor.BLUE));

                    Section section = chapter.AddSection(sTitle, 2);  //第二个参数表示树的深度
                }

                document.Add(chapter);

            }

            document.Close();
            Title = "简单使用";
        }
    }
}
