using System;
using System.Text;

namespace DirectoryTraversal
{

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> filesExtensions = new Dictionary<string, List<FileInfo>>();
            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!filesExtensions.ContainsKey(fileInfo.Extension))
                {
                    filesExtensions.Add(fileInfo.Extension, new List<FileInfo>());
                }

                filesExtensions[fileInfo.Extension].Add(fileInfo);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var fileExtension in filesExtensions.OrderByDescending(k => k.Value.Count))
            {
                sb.AppendLine($"{fileExtension.Key}");

                foreach (FileInfo file in fileExtension.Value.OrderBy(v => v.Length))
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(folderPath, textContent);
        }
    }
}
