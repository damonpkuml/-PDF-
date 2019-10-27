using System.IO;
using System.Windows;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Paragraph = iTextSharp.text.Paragraph;
using Section = iTextSharp.text.Section;

namespace 第四章_页眉页脚_章节_区域和绘图对象 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        //无边框页脚
        private void Button_Click(object sender, RoutedEventArgs e) {
            //todo: 原先document.header那种方式不存在了
            //需要通过回调方式

        }

        //1. 章节和区域(解决书签功能)
        //2 .章节之间默认会换页,就算前一章只占一行,当前章另起一页
        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Document document = new Document();

            PdfWriter.GetInstance(document, new FileStream("章节和区域.pdf", FileMode.OpenOrCreate));
            document.Open();

            //添加10章
            for (int i = 0; i < 10; i++) {
                //章节的标题
                Paragraph cTitle = new Paragraph($"This is chapter {i}", FontFactory.GetFont(
                    FontFactory.COURIER, 18));
                Chapter chapter = new Chapter(cTitle, i);

                //如果是偶数章节书签默认不打开
                if (i % 2 == 0) {
                    chapter.BookmarkOpen = false;
                }

                //每章添加20个区域
                for (int j = 0; j < 60; j++) {
                    //子区域
                    Paragraph sTitle = new Paragraph($"This is section {j} in chapter {i}",
                        FontFactory.GetFont(FontFactory.COURIER, 12, BaseColor.BLUE));

                    Section section = chapter.AddSection(sTitle, 2);  //第二个参数表示树的深度
                }

                document.Add(chapter);

            }

            document.Close();
            Title = "章节和区域";
        }

        //图形
        private void Button_Click_2(object sender, RoutedEventArgs e) {
            //todo: 老版本api
        }
    }
}
