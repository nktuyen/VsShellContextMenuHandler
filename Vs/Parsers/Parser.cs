using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ParseResult
    {
        internal Model Model { get; set; }
        internal bool Success { get; set; }
        internal string Content { get; set; }
        internal long Index { get; set; }
        internal long Length { get; set; }
        internal ParseResult(bool success = true, long length = 0)
        {
            Success = success;
            Content = string.Empty;
            Index = 0;
            Length = length;
            Model = null;
        }
    }

    public class Parser
    {
        public Model Model { get; protected set; }
        public File File { get; private set; }
        public Parser(File file)
        {
            this.File = file;
        }

        protected virtual ParseResult OnParse(string content) { return new ParseResult(true, content.Length ); }

        public ParseResult Parse(string lineData)
        {
            if (lineData == null)
                return null;

            if (lineData.Length <= 0)
                return null;

            return OnParse(lineData);
        }
    }
}
