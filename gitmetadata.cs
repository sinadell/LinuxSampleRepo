using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.Services.Search.Extensions.Libraries.reSearch.Core.IndexingMetadata
{
    public class GitMetadata
    {
        public string BranchName { get; private set; }

        public string CollectionName { get; private set; }

        public Uri RepositoryUri { get; private set; }

        public string Ref { get; private set; }

        protected GitMetadata()
        {
        }

        public static GitMetadata ReadFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            if (lines.Length < 4) throw new IOException("Incomplete GitMetadata: " + path);
            return CreateFromLines(lines);
        }

        public static GitMetadata CreateFromString(string content)
        {
            return CreateFromLines(ConfigHelper.GetLinesFromString(content));
        }

        public static GitMetadata CreateFromLines(IList<string> lines)
        {
            if (lines.Count < 4) throw new IOException("Incomplete GitMetadata");

            return new GitMetadata()
            {
                BranchName = lines[2],
                CollectionName = lines[1],
                RepositoryUri = new Uri(lines[0]),
                Ref = lines[3]
            };
        }
    }
}
