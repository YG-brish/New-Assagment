using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipeStreamPkg;

namespace HelloPipeline.Output
{

    class ConsoleWriter : IPipelineElement
    {
        PipeStream inputStream;

        public ConsoleWriter()
        {
            IsComplete = false;
        }

        public void SetInput(PipeStream input)
        {
            inputStream = input;
        }

        public void Connect(IPipelineElement next)
        {
            throw new InvalidOperationException("No output from this element");
        }

        public void Process()
        {
            if (inputStream.Length <= 0)
            {
                IsComplete = true;
                return;
            }

            byte[] buffer = new byte[1024];
            int bytesRead = 0;
            UTF8Encoding temp = new UTF8Encoding(true);

            while (inputStream.Length > 0)
            {
                bytesRead = inputStream.Read(buffer, 0, (buffer.Length < inputStream.Length) ? buffer.Length : (int)inputStream.Length);
                Console.WriteLine(temp.GetString(buffer, 0, bytesRead));
            }
        }

        public bool IsComplete
        {
            get;
            private set;
        }

    }
}
