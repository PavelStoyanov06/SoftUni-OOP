using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Stream_Progress
{
    public interface IStream
    {
        int BytesSent { get; set; }

        int Length { get; set; }
    }
}
