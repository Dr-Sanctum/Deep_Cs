
namespace T2_6
{
    internal interface ICalc
    {
        double Result { get; set; }

        double Sum(double x, double y);
        double Sub(double x, double y);
        double Divide(double x, double y);
        double Multy(double x, double y);

        public event EventHandler<EventArgs> CalcChange;


    }



}
