using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Stream_Progress
{
    public class CodeSheet : IStream
    {
        private string codeType;

        public CodeSheet(string codeType, int bytesSent, int length)
        {
            this.codeType = codeType;
            BytesSent = bytesSent;
            Length = length;
        }

        public int BytesSent { get; set; }
        public int Length { get; set; }
    }
}
