//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainApp.UI.Common.Views.Implementations.Views.Xamarin1 {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class PageDeviceStartTimer : ContentPage {
        
        private Label timeLabel;
        
        private Label dateLabel;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(PageDeviceStartTimer));
            timeLabel = this.FindByName<Label>("timeLabel");
            dateLabel = this.FindByName<Label>("dateLabel");
        }
    }
}
