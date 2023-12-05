using University.Domain.Exceptions.FileExceptions;

namespace University.Application.Common.Halpers
{
    public class MediaHelper
    {
        public static string MakeImageName(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);

            string[] ImageExtension = GetImageExtensions();

            if (ImageExtension.Any(x => x == fileInfo.Extension))
            {
                string extension = fileInfo.Extension;
                string name = "File_" + Guid.NewGuid() + extension;
                return name;
            }
            throw new FileNotValid();
        }

        public static string[] GetImageExtensions()
        {
            return new string[]
            {
            ".doc", ".docx",
            ".txt",
            ".ppt",
            ".pptx"
            };
        }
    }
}
