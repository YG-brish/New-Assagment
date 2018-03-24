using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipeStreamPkg;


namespace HelloPipeline.Input
{
   
    class FileReader :IPipelineElement
    {
        string      filePath;
        FileStream  fileStream;

        byte[]      buffer       = new byte[1024];
        PipeStream  outputStream = new PipeStreamPkg.PipeStream();

        public FileReader()
        {
            IsComplete    = false;

            string[] args = Environment.GetCommandLineArgs();
            filePath   = args[1];
            fileStream = new FileStream(filePath, FileMode.Open);
        }

        public void SetInput(PipeStream inputStream)
        {
            throw new InvalidOperationException("No input for this element");
        }

        public void Connect(IPipelineElement next)
        {
            next.SetInput(outputStream);
        }

      
        public void Process()
        {
            if(fileStream == null)
            {
                return;
            }

            int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
            IsComplete = bytesRead <= 0;

            if (bytesRead > 0)
            {
                outputStream.Write(buffer, 0, bytesRead);
            }
            else
            {
                fileStream.Dispose();
                fileStream = null;
            }
        }

        public bool IsComplete
        {
            get;
            private set;
        }
    }
}
