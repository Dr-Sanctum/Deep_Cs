//Спроектируйте интерфейс для класса способного устанавливать и
//получать значения отдельных бит в заданном числе.

namespace T2_2
{
    internal interface IBits
    {
        bool GetBit(int i);
        void SetBit(bool bit, int index);
    }
}
