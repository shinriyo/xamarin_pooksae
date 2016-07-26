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
        /// <summary>
        /// Downs the load CSV.
        /// </summary>
        /// <returns>The load CSV.</returns>
        /// <param name="dlLabel">Dl label.</param>
        public static void DownLoadCSVs(Label dlLabel)
        {
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                // ローカライズファイル.
                var localizeUrl = "http://vps6-d.kuku.lu/files/20160725-0035_2b21358ee0d5a871860a15789270a433.csv";
                var csvString = httpClient.GetStringAsync(localizeUrl).Result;
                dlLabel.Text += csvString;

                var csv = new CsvReader(new StringReader(csvString));
                while (csv.Read())
                {
                    var key = csv.GetField<string>(0);
                    var value = csv.GetField<string>(1);
                    Debug.WriteLine("key:{0}, value:{1}", key, value);
                }

                // パンチ系ファイル.
                var punchUrl = "http://vps6-d.kuku.lu/files/20160726-0053_cd22c32f91d04333262d320a8e49fd40.csv";
                Tools.LoadCSV(dlLabel, httpClient, punchUrl);

                // キック系ファイル.
                var kickUrl = "http://vps6-d.kuku.lu/files/20160725-0849_fbca8e210bea1a8b35e5b12ba70b0a14.csv";
                Tools.LoadCSV(dlLabel, httpClient, kickUrl);

                // チョップ系ファイル.
                var chopUrl = "http://vps6-d.kuku.lu/files/20160725-0856_7759c7a4b8b7b3dd5613576968451f6d.csv";
                Tools.LoadCSV(dlLabel, httpClient, chopUrl);

                // 受け系ファイル.
                var guardUrl = "http://vps6-d.kuku.lu/files/20160726-0057_e3d23c791475be2247fa60c3c7de91bd.csv";
                Tools.LoadCSV(dlLabel, httpClient, guardUrl);

                // TODO: これを上で同時に.
                Tools.InitializeDB();
            }
        }

        /// <summary>
        /// Loads the csv.
        /// </summary>
        /// <returns>The csv.</returns>
        /// <param name="dlLabel">Dl label.</param>
        /// <param name="httpClient">Http client.</param>
        /// <param name="url">URL.</param>
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
                language = "ja",
                version = "0.1"
            };
            sc.Insert(setting);

            // 技の初期化.
            // TODO: CSVでやる？.
            var artModelController = new Controller<ArtModel>();

            var apchagi = new ArtModel
            {
                Country = "ja",
                Kyu = 0,
                Name = "a",
                Desc = "b",
                Detail = "b",
                Picture = "b"
            };
            artModelController.Insert(apchagi);
        }
    }
}
