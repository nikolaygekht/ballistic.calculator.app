# Ballistic Calculator .NET

100% open source windows (100% WinE compatible) ballistic calculator with accuracy and performance comparable with best commercial calculators.

The application is under development now!!! Please stay in touch. I expect the first release by ~~September 2021~~November, 2022. You can track the progress on the project page. You can share your suggestions or ideas in discussions. 

If you need something to use right now, take a look at OLD version of the application 
* [Sourceforge](https://sourceforge.net/projects/ballisticcalculator/)
* [GitHub](https://github.com/nikolaygekht/ballistic.calculator.app.old)

## RISK NOTICE

The application performs very limited simulation of a complex physical process and so it performs a lot of approximations. Therefore the calculation results MUST NOT be considered as completely and reliably reflecting actual behavior or characteristics of projectiles. While these results may be used for educational purpose, they must NOT be considered as reliable for the areas where incorrect calculation may cause making a wrong decision, financial harm, or can put a human life at risk.

THE CODE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE MATERIALS OR THE USE OR OTHER DEALINGS IN THE MATERIALS.

## See also

* [How to run application on Linux using Wine](https://github.com/nikolaygekht/ballistic.calculator.app/wiki/How-to-run-application-on-Linux-using-Wine)
* [Related and friendly projects](https://github.com/nikolaygekht/ballistic.calculator.app/wiki/Related-and-friendly-projects)
* [What should I read about external ballistics?](https://github.com/nikolaygekht/ballistic.calculator.app/wiki/What-should-I-read-about-external-ballistics%3F)

## 3rd Party Components used

* Scott Plot for WinForms [nuget](https://www.nuget.org/packages/ScottPlot.WinForms)
* Ballistic Caculator [git](https://github.com/gehtsoft-usa/BallisticCalculator1)
* Measurements/Unit Conversion [git](https://github.com/gehtsoft-usa/Gehtsoft.Measurements) [nuget](https://www.nuget.org/packages/Gehtsoft.Measurements)

## Project Structure

* `BallisticCalculatorNet`
  
  The calculator application. 

  The application mostly defines the windows, menus and the command logic. All input and output is made trough custom panels. 
  The panels are in `BallisticCalculatorNet.InputPanels` library.

* `BallisticCalculatorNet.Common`

  Common service classes used in both, the calculator application and the reticle editor

* `BallisticCalculatorNet.InputPanels`

  The input panels to enter data for calculation and to output the results.  
  All panels are made in form of custom controls and then used in the calculator application.

* `BallisticCalculatorNet.MeasurementControl`

   A custom control to enter a measurement (e.g. distance, weight).

* `BallisticCalculatorNet.ReticleCanvas`

   A custom control to paint a reticle.

* `BallisticCalculatorNet.ReticleEditor`
 
   The editor for reticles. 

* `BallisticCalculatorNet.UnitTest`
 
   Unit and integration tests.

* `Gehtsoft.Winforms.FluentAssertions`

  Fluent assertions for winforms controls.

* `Gehtsoft.Winforms.FluentAssertions.Test`

  Test of fluent assertions for winforms controls.
  
* `data`

   Data files: ammunition descriptions, drag tables, reticles. 


