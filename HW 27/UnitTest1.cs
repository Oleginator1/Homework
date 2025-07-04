using Exercise;

namespace UnitTesting
{
    public class StringValidatorTests
    {
        [Theory]
        [InlineData ("test@gmail.com", true)]
        [InlineData("invalidemail", false)]
        [InlineData("user@domain", false)]
        [InlineData("user.domain.com", false)]
        public void IsValidEmailShouldReturnExpected_Test(string email, bool expected)
        {            
            var result = StringValidator.IsValidEmail(email);
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("0720123456", true)]
        [InlineData("123abc4567", false)]
        [InlineData("123456789", false)] 
        [InlineData("12345678901", false)]

        public void IsPhoneNumberShouldRetrunExpected_Test(string phoneNumber, bool expected)
        {
            var result = StringValidator.IsPhoneNumber(phoneNumber);
            Assert.Equal(expected, result);
        }
    }



    public class StringUtilsTest
    {
        private readonly StringUtils utils = new StringUtils();


        [Theory]
        [InlineData("asdf", "fdsa")]
        [InlineData("12345", "54321")]
        [InlineData("", "")]
        public void Reverse_Should_Return_A_Reversed_String_Test(string input, string expected)
        {
            var result = utils.Reverse(input);
            Assert.Equal(result , expected);
        }


        [Theory]
        [InlineData("ana", true)]
        [InlineData("A man a plan a canal Panama", true)]
        [InlineData("chatGPT", false)]
        [InlineData("Never odd or even", true)]
        [InlineData("Not a palindrome", false)]

        public void IsPalindrom_Should_Return_Expected_Test(string palindrome, bool expected)
        {
            var result = utils.IsPalindrome(palindrome);
            Assert.Equal(expected, result);
        }
    }
}