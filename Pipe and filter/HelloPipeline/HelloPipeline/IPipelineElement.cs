using PipeStreamPkg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPipeline
{
    interface IPipelineElement
    {
       void SetInput(PipeStream inputStream);

        void Connect(IPipelineElement next);

         void Process();

       bool IsComplete
        {
            get;
        }
    }
}
