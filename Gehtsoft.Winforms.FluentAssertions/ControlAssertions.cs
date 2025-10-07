using FluentAssertions.Execution;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gehtsoft.Winforms.FluentAssertions
{
    public class ControlAssertions : ControlAssertionsBase<Control, ControlAssertions>
    {
        public ControlAssertions(Control subject) : base(subject)
        {
        }
    }
}
