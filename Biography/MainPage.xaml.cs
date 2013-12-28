using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using EPubReader;

namespace Biography
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            EPubViewer.Source = Application.GetResourceStream(new Uri("/Biography;component/files/123.epub", UriKind.Relative)).Stream;

            if (EPubViewer.HasCover)
                EPubViewer.State = EPubReader.State.Cover;
            // Show table of contents
            else if (EPubViewer.HasToc)
                EPubViewer.State = EPubReader.State.Toc;
        }

        private void EPubViewer_Tap(object sender, GestureEventArgs e)
        {
            if (EPubViewer.State != EPubReader.State.Normal)
                return;
            if (e.GetPosition(EPubViewer).X == 1 && EPubViewer.CurrentLocation > 29)
                EPubViewer.CurrentLocation--;
            else if (e.GetPosition(EPubViewer).X >= 320 && EPubViewer.CurrentLocation < EPubViewer.FurthestLocation - 1)
                EPubViewer.CurrentLocation++;
            //else if (EPubViewer.CurrentLocation < 5)
                //EPubViewer.HasToc
            
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            EPubViewer.CurrentLocation = 1;
        }
    }
}