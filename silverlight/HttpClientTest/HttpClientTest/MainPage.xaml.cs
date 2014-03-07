using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace HttpClientTest {

    public partial class MainPage {

        public MainPage() {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e) {
            await HttpTest();
        }

        async Task HttpTest() {
            var client = new HttpClient {
                                            BaseAddress = new Uri("http://localhost:2493/")
                                        };
            var request = new HttpRequestMessage(HttpMethod.Get, "HttpClientTestTestPage.html");
            var response = await client.SendAsync(request);
            var contentType = response.Content.Headers.ContentType;
            if (contentType == null) {
                MessageBox.Show("Content Type is null");
            }
            else {
                MessageBox.Show(string.Format("content type is: {0}", contentType));
            }
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) {
                MessageBox.Show("Content Type is null");
            }
            else {
                MessageBox.Show(string.Format("content type is: {0}", content));
            }
        }
    }
}
