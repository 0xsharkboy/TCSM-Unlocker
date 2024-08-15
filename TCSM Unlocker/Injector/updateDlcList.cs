using HtmlAgilityPack;
using Microsoft.VisualBasic;
using System.ComponentModel;

namespace TCSM_Unlocker
{
    internal class updateDlcList
    {
        private void clearFolder(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);

            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        private async Task<List<string>> getDlcList()
        {
            string apiUrl = "https://store.steampowered.com/search/?term=the+texas+chain+saw+massacre";

            List<string> appIds = new List<string>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(responseBody);

                    var appIdNodes = htmlDoc.DocumentNode.SelectNodes("//*[@data-ds-appid]");

                    if (appIdNodes != null)
                    {
                        foreach (var node in appIdNodes)
                        {
                            string appId = node.GetAttributeValue("data-ds-appid", null);
                            string link = node.GetAttributeValue("href", null);

                            if (appId != null && link.Contains("The_Texas_Chain_Saw_Massacre"))
                            {
                                appIds.Add(appId);
                            }

                        }
                        return appIds;
                    }
                    else
                    {
                        Console.WriteLine("No appId found.");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Error while calling the API : " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error while saving response : " + e.Message);
                }
            }
            return null;
        }

        public async void updateDlcFromSteam()
        {
            string appListPath = @"AppList\";
            List<string> appIds = await this.getDlcList();

            if (appIds != null)
            {
                if (Directory.Exists(appListPath))
                {
                    this.clearFolder(appListPath);
                }
                else
                {
                    Directory.CreateDirectory(appListPath);
                }

                for (int i = 0; i < appIds.Count; i++)
                {
                    string filePath = Path.Combine(appListPath, $"{i}.txt");

                    File.WriteAllText(filePath, appIds[i]);
                }
            }
            else
            {
                Console.WriteLine("Unable to update DLC list");
            }
        }
    }
}

