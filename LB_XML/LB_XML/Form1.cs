using System.Net;
using System.Xml;


namespace LB_XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox_OnInitialization();
        }

        private void rssFullTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void newsInfoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            var newsInfo = new Dictionary<string, string?>()
            {
                { "title", "" },
                { "description", ""},
                { "pubDate", ""},
                { "link", ""}
            };

            string rssLink = linkTextBox.Text;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(rssLink);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string stringNews = (new StreamReader(response.GetResponseStream())).ReadToEnd();

            rssFullTextBox.Text = stringNews;

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(stringNews);
            XmlElement? xRoot = xmlDoc.DocumentElement;

            if (xRoot != null)
            {
                XmlNodeList? childNodeList =
                xRoot.SelectSingleNode("channel")?.SelectNodes("item");

                if (childNodeList != null)
                {
                    foreach (XmlNode xmlNode in childNodeList)
                    {
                        foreach (string Key in newsInfo.Keys)
                        {
                            newsInfo[Key] = xmlNode?.SelectSingleNode(Key)?.InnerText;
                        }

                        newsInfoTextBox.Text += 
                            $"Название:\n" +
                            $"{newsInfo["title"]}\n\n" +
                            $"Аннотация:\n" +
                            $"{newsInfo["description"]}\n\n" +
                            $"Дата и время публикации:\n" +
                            $"{newsInfo["pubDate"]}\n\n" +
                            $"Ссылка:\n" +
                            $"{newsInfo["link"]}\n\n" +
                            $"===================================\n\n";
                    }
                }
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
            => linkTextBox.Text = comboBox.SelectedItem as string;
        private void comboBox_OnInitialization()
        {
            string[] options =
            {
                "https://ria.ru/export/rss2/archive/index.xml",
                "https://lenta.ru/rss/articles",
            };

            comboBox.Items.AddRange(options);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
