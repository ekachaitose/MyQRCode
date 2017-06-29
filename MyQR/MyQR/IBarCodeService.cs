using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQR
{
  public interface IBarCodeService
    {

        Stream GenerateBarCode(string text, int width = 500, int height = 500);

    }
}
