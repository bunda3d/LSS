using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSS.Shared.Entities
{
  public class Color
  {
    public int Id { get; set; }
    public string ColorName { get; set; }
    public string ColorHexCode { get; set; }
    public string ColorHsvCode { get; set; }
    public string ColorPantoneCode { get; set; }
    public string ColorDyeName { get; set; }
    public bool WasUsedInProductionFlag { get; set; }
    public string ColorUsedInProductId { get; set; }

  }
}
