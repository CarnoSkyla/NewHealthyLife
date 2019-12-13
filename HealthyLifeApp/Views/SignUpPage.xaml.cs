using Xamarin.Forms;

namespace HealthyLifeApp.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            
           
           
        }

        private void SwitchGender_Toggled(object sender, ToggledEventArgs e)
        {
            var count = 0;
            
            if(count % 2 == 0)
            {
                Gender.Text = "Female";
            }
            else
            {
                Gender.Text = "Male";
            }
           
        }
    }
}
