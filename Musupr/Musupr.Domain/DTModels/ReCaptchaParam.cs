using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musupr.Domain.DTModels
{
    public class ReCaptchaParam<T>
    {
        public string reCaptchaResponse { get; set; }
        public T param { get; set; }
    }
}
