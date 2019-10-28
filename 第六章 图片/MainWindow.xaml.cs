using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
using Image = iTextSharp.text.Image;

namespace 第六章_图片 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        //通过Url方式获取图片
        private void Button_Click(object sender, RoutedEventArgs e) {
            Document document = new Document();

            PdfWriter.GetInstance(document, new FileStream("Url获取图片.pdf",
                FileMode.OpenOrCreate));

            document.Open();

            //uri方式
            //Image image = Image.GetInstance(new Uri("images/11.jpg",UriKind.Absolute));

            //document.Add(image);


            //路径
            Image image2 = Image.GetInstance("11.jpg");  //图片放在/bin/debug下
            image2.ScaleToFit(document.PageSize); //缩放图片
            //Chunk chunk=new Chunk(image2,);
            
            document.Add(image2);
            
            document.Close();

            Title = "图片";

        }
    }
}
