using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_s.ResultView
{
    public class ResultView<T>
    {
      
            public T Entity { get; set; }
            public bool IsSuccesed { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
