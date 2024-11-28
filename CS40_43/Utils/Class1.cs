namespace TT.Utils;

public static class CovertMoneyToText
{
    public static string NumberToText(double inputNumber, bool suffix = true)
    {
        string[] unitNumbers = new string[] { "khong", "mot", "hai", "ba", "bon", "nam", "sau", "bay", "tam", "chin" };
        string[] placeValues = new string[] { "", "nghin", "trieu", "ty" };
        bool isNegative = false;

        // -12345678.3445435 => "-12345678"
        string sNumber = inputNumber.ToString("#");
        double number = Convert.ToDouble(sNumber);
        if (number < 0)
        {
            number = -number;
            sNumber = number.ToString();
            isNegative = true;
        }


        int ones, tens, hundreds;

        int positionDigit = sNumber.Length;   // last -> first

        string result = " ";


        if (positionDigit == 0)
            result = unitNumbers[0] + result;
        else
        {
            // 0:       ###
            // 1: nghìn ###,###
            // 2: triệu ###,###,###
            // 3: tỷ    ###,###,###,###
            int placeValue = 0;

            while (positionDigit > 0)
            {
                // Check last 3 digits remain ### (hundreds tens ones)
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
                        result = "lam " + result;
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
        if (isNegative) result = "am " + result;
        return result + (suffix ? " đong chan" : "");
    }
}
