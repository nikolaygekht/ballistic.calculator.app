using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    public class ControlAssertions : ControlAssertionsBase<Control, ControlAssertions>
    {
        public ControlAssertions(Control subject) : base(subject)
        {
        }
    }
}
