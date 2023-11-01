
namespace T2_5
{
    internal interface ICalc
    {
        double Result { get; set; }

        double Sum(int x, int y);
        double Sub(int x, int y);
        double Divide(int x, int y);
        double Multy(int x, int y);

        public event EventHandler<EventArgs> CalcChange;


    }



}
