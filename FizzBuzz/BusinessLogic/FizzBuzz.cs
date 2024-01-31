using FizzBuzz.Interfaces;
using FizzBuzz.Constants;

namespace FizzBuzz.BusinessLogic
{
    public class FizzBuzz : IFizzBuzz
    {

        public readonly IDivisible _iDivisible;

       
        public FizzBuzz(IDivisible iDivisible)
        {
            _iDivisible = iDivisible;
        }

        //Assumptions : Float and doublt values not accepted
        public List<string> GetFizzBuzzList(List<string> lstInput, List<int> divValues)
        {
           List<string> lstOutput = new List<string>();
           List<int> lstdivVal = new List<int>();
           int i = 0;

           //Retrieve the divisble values
            if (divValues.Count > 0)
            {
                foreach (var val in divValues)
                {
                    lstdivVal.Add(val);
                }   
            }

            if (lstInput.Count > 0)
            { 
                foreach (var item in lstInput)
                {                    
                    if (int.TryParse(item, out i))
                    {
                        if (_iDivisible.IsDivisible(i, lstdivVal[0]) && _iDivisible.IsDivisible(i, lstdivVal[1]))
                        {
                            lstOutput.Add(item + " - " + Constants.Constants.strFizzBuzz);
                        }
                        else if (_iDivisible.IsDivisible(i, lstdivVal[0]))
                        {
                            lstOutput.Add(item + " - " + Constants.Constants.strFizz);
                        }
                        else if (_iDivisible.IsDivisible(i, lstdivVal[1]))
                        {
                            lstOutput.Add(item + " - " + Constants.Constants.strBuzz);
                        }
                        else
                        {
                            lstOutput.Add("Divided " + item + " by 3 & Divided " + item + " by 5");
                        }
                    }
                    else
                    {
                        lstOutput.Add(item + " - " + Constants.Constants.strInvalidItem);
                    }
                }
            }
            else
            {
                lstOutput.Add(Constants.Constants.strInvalidInput);
            }
            return lstOutput;

        }
    }
}
