namespace CS09
{
    class Program09
    {
        public static void Run()
        {
            var snumber = NumberToText(2024);
            Console.WriteLine(snumber);
            //int ntest = 1000;
            //Random rn = new Random();
            //for (int i = 0; i < ntest; i++)
            //{
            //    var number = rn.NextDouble() * rn.Next(1, Int32.MaxValue);
            //    var text = XTL.Utils.NumberToText(number);
            //    var ntext = number.ToString("###,###,###,###,###");
            //    Console.WriteLine($"{ntext,20} --> {text}");
            //}
        }

        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "khong", "mot", "hai", "ba", "bon", "nam", "sau", "bay", "tam", "chin" };
            string[] placeValues = new string[] { "", "nghin", "trieu", "ty" };
            bool isNegative = false;

            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "mot " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "nam " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "le " + result;
                        if (tens == 1) result = "muoi " + result;
                        if (tens > 1) result = unitNumbers[tens] + " muoi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " tram " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Am " + result;
            return result + (suffix ? " dong chan " : "");
        }
    }
}