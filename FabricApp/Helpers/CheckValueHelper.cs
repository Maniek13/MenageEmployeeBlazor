using FabricAPP.Exceptions;

namespace FabricAPP.Helpers
{
    public class CheckValueHelper
    {
        public static void CheckIsPhoneNr(string nr)
        {
            if (string.IsNullOrEmpty(nr))
                throw new IncorectValueOfUserException("Plese write a number");

            if (nr.Length < 9)
                throw new IncorectValueOfUserException("Number must have more then 8 digits");

            for (int i = 0; i < nr.Length; ++i)
            {

                if (!int.TryParse(nr[i].ToString(), out _))
                {
                    throw new IncorectValueOfUserException($"Phone number must have only numeric value but have a/an {nr[i]} in position {i+1}");
                }
            }
        }
        public static void CheckIsZipNumbers(string nr)
        {
            if (string.IsNullOrEmpty(nr))
                throw new IncorectValueOfUserException("Plese write a zip code");

            if (string.IsNullOrEmpty(nr) || nr.Length != 5)
                throw new IncorectValueOfUserException("Zip code must have 5 digits. Format: 00000");


            for(int i = 0; i < nr.Length; ++i) 
            {
                if(!int.TryParse(nr[i].ToString(), out _)) 
                {
                    throw new IncorectValueOfUserException($"ZIP code must have only numeric value but have a/an {nr[i]} in position {i+1}");
                }
            }
        }
    }
}
