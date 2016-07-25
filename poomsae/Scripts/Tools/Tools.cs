namespace CellTool
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    /// <summary>
    /// Data.
    /// </summary>
    public class Data
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Picture { get; set; }
        public ICommand OnClick { get; set; }
    }

    /// <summary>
    /// Group.
    /// </summary>
    public class Group : ObservableCollection<Data>
    {
        public string Title { get; private set; }
        public Group(string title)
        {
            Title = title;
        }
    }
}

namespace Poomsae
{
    using System.Diagnostics;
    using System.IO;
    using CsvHelper;
    using Realms.Tool;
    using Xamarin.Forms;

    /// <summary>
    /// Tools.
    /// </summary>
    public static class Tools
    {
        public static void LoadCSV(Label dlLabel, System.Net.Http.HttpClient httpClient, string url)
        {
            var csvString = httpClient.GetStringAsync(url).Result;
            dlLabel.Text += csvString;

            var csv = new CsvReader(new StringReader(csvString));
            while (csv.Read())
            {
                var kyu = csv.GetField<int>(0);
                var name = csv.GetField<string>(1);
                var desc = csv.GetField<string>(2);
                var detail = csv.GetField<string>(3);
                var picture = csv.GetField<string>(4);
                Debug.WriteLine("Kyu:{0}, Name:{1}, Desc:{2}, " +
                                "Detail:{3}, Picture{0} ",
                                kyu, name, desc, detail, picture);
            }
        }

        /// <summary>
        /// Initializes the db.
        /// </summary>
        /// <returns>The db.</returns>
        public static void InitializeDB()
        {
            Debug.WriteLine(new string('*', 10));
            var languageController = new Controller<Localize>();
            // 一旦消して.
            languageController.DeleteAll();

            var ja = new Localize { Country = "ja" };
            var enUS = new Localize { Country = "en-US" };
            var kr = new Localize { Country = "kr" };
            languageController.Insert(ja);
            languageController.Insert(enUS);
            languageController.Insert(kr);

            var sc = new Controller<Setting>();
            sc.DeleteAll();
            var setting = new Setting()
            {
                language = "Japan",
                version = "0.1"
            };
            sc.Insert(setting);

            // 技の初期化.
            // TODO: CSVでやる？.
            var artModelController = new Controller<ArtModel>();

            var apchagi = new ArtModel
            {
                Country = "ja",
            };
            artModelController.Insert(apchagi);
        }
    }
}
