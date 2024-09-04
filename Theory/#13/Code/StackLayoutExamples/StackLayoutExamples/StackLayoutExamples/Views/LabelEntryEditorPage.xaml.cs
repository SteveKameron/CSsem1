using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StackLayoutExamples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelEntryEditorPage : ContentPage
    {
        public LabelEntryEditorPage()
        {
            InitializeComponent();
        }

     

        private void Editor1_Completed(object sender, EventArgs e)
        {
            Label1.Text = Editor1.Text;
        }

        private void Entry1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Label1.Text = Entry1.Text;
        }
    }
}