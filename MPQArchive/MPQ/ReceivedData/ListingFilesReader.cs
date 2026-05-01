using MPQArchive.MPQ.Constants;
using MPQArchive.MPQ.DecryptedData;
using System.Diagnostics;
using System.Text;

namespace MPQArchive.MPQ.ReceivedData
{
    public class ListingFilesReader(MPQFileReader mpqFileReader)
    {
        public Dictionary<string, ArraySegment<byte>> Read()
        {
            var listingFiles = mpqFileReader.ReadFile("(listfile)");
            var fileContent = Encoding.UTF8.GetString(listingFiles);
            var lines = fileContent
                .Split(["\r\n", "\r", "\n"], StringSplitOptions.None)
                .Where(listingFile => MPQListingFileConstant.UsedListingFiles.Contains(listingFile));
          
            var listingFilesDict = new Dictionary<string, ArraySegment<byte>>();
            var count = 0;

            foreach (var listingFile in lines)
            {
                if (!string.IsNullOrEmpty(listingFile))
                {
                    listingFilesDict.Add(listingFile, mpqFileReader.ReadFile(listingFile));
                }

                ++count;
            }

            return listingFilesDict;
        }
    }
}
