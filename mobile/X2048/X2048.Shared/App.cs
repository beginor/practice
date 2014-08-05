using System;
using System.Collections.Generic;
using System.Text;
using Beginor.X2048.Views;
using Xamarin.Forms;

namespace Beginor.X2048 {

    public static class App {

        public static Page GetMainPage() {
            return new MainPage();
        }
    }
}
