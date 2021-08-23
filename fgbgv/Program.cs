using System;
using System.Windows;
using DRAFTINGITF;
using shared;

namespace fgbgv
{
    class Program
    {
        static void Main(string[] args)
        {
            const string caption = "Foreground - Background view";
            const int foreground = 1;
            const int background = 2;
            try
            {
                var catia = Bootstrap.Init();
                var activeDoc = catia.ActiveDocument;
                if (!Bootstrap.IsDocValid(activeDoc, DocType.Drawing))
                {
                    MessageBox.Show("Expected drawing document", caption,
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }

                var activeSheet = ((DrawingDocument)activeDoc).Sheets.ActiveSheet; // Cannot be null
                var views = activeSheet.Views;
                views.Item(views.ActiveView == views.Item(foreground) ? background : foreground).Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}