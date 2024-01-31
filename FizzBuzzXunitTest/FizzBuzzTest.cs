using FizzBuzz.BusinessLogic;
using FizzBuzz.Constants;
using FizzBuzz.Controllers;
using FizzBuzz.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FizzBuzzXunitTest
{
    public class FizzBuzzTest
    {

        private readonly IConfiguration _iConfiguration;
        private readonly IFizzBuzz iFizzBuzz;
        private readonly IDivisible iDivisible;


        public FizzBuzzTest() 
        {
            iDivisible = new Divisible();
            iFizzBuzz = new FizzBuzz.BusinessLogic.FizzBuzz(iDivisible);
            _iConfiguration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@"appsettings.json", false, false).AddEnvironmentVariables().Build();

        }      


        [Fact]
        public void GetFizzBuzzListForIntValuesOnly()
        {           
            //arrange
            List<string> inputList = new List<string>();
            inputList.Add("3");
            inputList.Add("5");
            inputList.Add("15");
          
            FizzBuzzController fz = new FizzBuzzController(iFizzBuzz, _iConfiguration);

            //act 
            List<string> outputList = fz.GetFizzBuzzResults(inputList);
            //assert
            Assert.NotNull(outputList);
            Assert.NotEmpty(outputList);
            Assert.Equal(inputList[0] + " - " + Constants.strFizz, outputList[0]);
            Assert.Equal(inputList[1] + " - " + Constants.strBuzz, outputList[1]);
            Assert.Equal(inputList[2] + " - " + Constants.strFizzBuzz, outputList[2]);         
        }

        [Fact]
        public void GetFizzBuzzListForStringValuesOnly()
        {
            //arrange
            List<string> inputList = new List<string>();
            inputList.Add("One");
            inputList.Add("Two");
            inputList.Add("Three");
            inputList.Add("Four");
            FizzBuzzController fz = new FizzBuzzController(iFizzBuzz,_iConfiguration);

            //act 
            List<string> outputList = fz.GetFizzBuzzResults(inputList);
            //assert
            Assert.NotNull(outputList);
            Assert.NotEmpty(outputList);
            Assert.Equal(inputList[0] + " - " + Constants.strInvalidItem, outputList[0]);
            Assert.Equal(inputList[1] + " - " + Constants.strInvalidItem, outputList[1]);
            Assert.Equal(inputList[2] + " - " + Constants.strInvalidItem, outputList[2]);
            Assert.Equal(inputList[3] + " - " + Constants.strInvalidItem, outputList[3]);
        }

        [Fact]
        public void GetFizzBuzzListForIntValuesWithEmptyString()
        {
            //arrange
            List<string> inputList = new List<string>();
            inputList.Add("1");           
            inputList.Add("");
            FizzBuzzController fz = new FizzBuzzController(iFizzBuzz,_iConfiguration);

            //act 
            List<string> outputList = fz.GetFizzBuzzResults(inputList);
            //assert
            Assert.NotNull(outputList);
            Assert.NotEmpty(outputList);
            Assert.Equal(inputList[1] + " - " + Constants.strInvalidItem, outputList[1]);
        }

        [Fact]
        public void GetFizzBuzzListForStringValuesWithEmptyString()
        {
            //arrange
            List<string> inputList = new List<string>();
            inputList.Add("Five");
            inputList.Add("Seven");          
            inputList.Add("");
            FizzBuzzController fz = new FizzBuzzController(iFizzBuzz, _iConfiguration);

            //act 
            List<string> outputList = fz.GetFizzBuzzResults(inputList);
            //assert
            Assert.NotNull(outputList);
            Assert.NotEmpty(outputList);
            Assert.Equal(inputList[0] + " - " + Constants.strInvalidItem, outputList[0]);
            Assert.Equal(inputList[2] + " - " + Constants.strInvalidItem, outputList[2]);
        }
        [Fact]
        public void GetFizzBuzzListForEmptyList()
        {
            //arrange
            List<string> inputList = new List<string>();
            FizzBuzzController fz = new FizzBuzzController(iFizzBuzz, _iConfiguration);

            //act 
            List<string> outputList = fz.GetFizzBuzzResults(inputList);
            //assert
            Assert.NotNull(outputList);
            Assert.NotEmpty(outputList);
            Assert.Equal(Constants.strInvalidInput, outputList[0]);
        }

        [Fact]
        public void GetFizzBuzzResultForNonDivisibleInt()
        {

            //arrange
            List<string> inputList = new List<string>();
            inputList.Add("2");            
            FizzBuzzController fz = new FizzBuzzController(iFizzBuzz, _iConfiguration);
            string nonDivisibleOutput = "Divided " + inputList[0] + " by 3 & Divided " + inputList[0] + " by 5";
            //act 
            List<string> outputList = fz.GetFizzBuzzResults(inputList);
            //assert
            Assert.NotNull(outputList);
            Assert.NotEmpty(outputList);
            Assert.Equal(nonDivisibleOutput, outputList[0]);          

        }

        [Fact]
        public void GetFizzBuzzListForStringValuesWithFloatValue()
        {
            //arrange
            List<string> inputList = new List<string>();
            inputList.Add("0.5");          
            FizzBuzzController fz = new FizzBuzzController(iFizzBuzz, _iConfiguration);

            //act 
            List<string> outputList = fz.GetFizzBuzzResults(inputList);
            //assert
            Assert.NotNull(outputList);
            Assert.NotEmpty(outputList);
            Assert.Equal(inputList[0] + " - " + Constants.strInvalidItem, outputList[0]);
        }

        [Fact]
        public void GetFizzBuzzListForStringValuesWithNegativeValue()
        {
            //arrange
            List<string> inputList = new List<string>();
            inputList.Add("-5");
            inputList.Add("-9");
            inputList.Add("-15");
            FizzBuzzController fz = new FizzBuzzController(iFizzBuzz, _iConfiguration);

            //act 
            List<string> outputList = fz.GetFizzBuzzResults(inputList);
            //assert
            Assert.NotNull(outputList);
            Assert.NotEmpty(outputList);
            Assert.Equal(inputList[0] + " - " + Constants.strBuzz, outputList[0]);
            Assert.Equal(inputList[1] + " - " + Constants.strFizz, outputList[1]);
            Assert.Equal(inputList[2] + " - " + Constants.strFizzBuzz, outputList[2]);
        }

        [Fact]
        public void GetFizzBuzzListForStringValuesWithNegativeNonDivisibleValue()
        {
            //arrange
            List<string> inputList = new List<string>();
            inputList.Add("-8");           
            FizzBuzzController fz = new FizzBuzzController(iFizzBuzz, _iConfiguration);
            string nonDivisibleOutput = "Divided " + inputList[0] + " by 3 & Divided " + inputList[0] + " by 5";

            //act 
            List<string> outputList = fz.GetFizzBuzzResults(inputList);
            //assert
            Assert.NotNull(outputList);
            Assert.NotEmpty(outputList);
            Assert.Equal(nonDivisibleOutput, outputList[0]);
        
        }
    }
}