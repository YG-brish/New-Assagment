using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPipeline
{
   class Pipeline
    {
        List<IPipelineElement> pipeline = new List<IPipelineElement>(); 

        public void Add(IPipelineElement anElement)
        {
            pipeline.Add(anElement);
            if (pipeline.Count > 1)
                pipeline[pipeline.Count - 2].Connect(pipeline[pipeline.Count - 1]);
        }

        public void Run()
        {
            bool jobCompleted = false;

           
            while (!jobCompleted)
            {
                jobCompleted = true;
                for (int i = 0; i < pipeline.Count; i++)
                {
                    pipeline[i].Process();
                    jobCompleted = jobCompleted && pipeline[i].IsComplete;
                }
            }
        }
    }
}
