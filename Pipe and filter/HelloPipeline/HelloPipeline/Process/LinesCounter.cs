using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPipeline.Process
{
   
    class LinesCounter :IPipelineElement
    {
        PipeStreamPkg.PipeStream input;
        PipeStreamPkg.PipeStream output = new PipeStreamPkg.PipeStream();

        public LinesCounter()
        {
            IsComplete = false;
        }

        public void SetInput(PipeStreamPkg.PipeStream inputStream)
        {
            input = inputStream;
        }

        public void Connect(IPipelineElement next)
        {
            next.SetInput(output);
        }

        int numberOfLine = 0;

        public void Process()
        {
            if (input.Length <= 0)
            {
                IsComplete = true;
                byte[] strbuf = new UTF8Encoding().GetBytes(string.Format("Number of lines = {0}", numberOfLine));
                output.Write(strbuf, 0, strbuf.Length);
                return;
            }

            byte[] buffer = new byte[1024];
            int bytesRead = 0;

            while(input.Length > 0)
            {
                bytesRead = input.Read(buffer, 0, (buffer.Length < input.Length) ? buffer.Length : (int)input.Length);

                for (int i = 0; i < bytesRead; i++)
                {
                    if (buffer[i] == '\n')
                    {
                        numberOfLine++;
                    }
                }
            }
        }

        public bool IsComplete
        {
            get;
            private set;
        }
    }
}
