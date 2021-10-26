using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.CustomValidators
{
    public class LuhnCheck
    {
        public bool PassesLuhnCheck(string creditCardNumber)
        {
            bool isValidCC = false;
            var normCreditCardNum = NormalizeString(creditCardNumber);
            if (!string.IsNullOrWhiteSpace(normCreditCardNum))
            {
                isValidCC = Luhn(normCreditCardNum);
            }
            return isValidCC;
        }

        public string NormalizeString(string creditCardNumber)
        {
            return creditCardNumber.Replace("-", string.Empty).Replace(" ", string.Empty).Trim();
        }


        public static bool Luhn(string digits)
        {
            return digits.All(char.IsDigit) && digits.Reverse()
                .Select(c => c - 48)
                .Select((thisNum, i) => i % 2 == 0
                    ? thisNum
                    : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
                ).Sum() % 10 == 0;
        }
    }
}
