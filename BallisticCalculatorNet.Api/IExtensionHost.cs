using System.Collections.Generic;
using System.Text;

namespace BallisticCalculatorNet.Api
{
    /// <summary>
    /// The interface to extension host
    /// </summary>
    public interface IExtensionHost
    {
        /// <summary>
        /// Returns the currently active form
        /// 
        /// You can check each form whether it implements <see cref="IShotForm"/> to get the associated trajectory.
        /// </summary>
        /// <returns></returns>
        object ActiveForm();

        /// <summary>
        /// Returns all forms
        /// 
        /// You can check each form whether it implements <see cref="IShotForm"/> to get the associated trajectory.
        /// </summary>
        /// <returns></returns>
        object[] AllForms();
    }
}
