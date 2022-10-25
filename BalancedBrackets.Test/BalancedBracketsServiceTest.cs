using BalancedBrackets.Service;
using System;
using Xunit;

namespace BalancedBrackets.Test
{
    public class BalancedBracketsServiceTest
    {
        private BalancedBracketsService _service;

        public BalancedBracketsServiceTest()
        {
            _service = new BalancedBracketsService();
        }

        #region False

        [Fact]
        public void SendNullString_ReturnFalse()
        {
            var isBalanced = _service.CheckBalance(null);

            Assert.False(isBalanced);
        }

        [Fact]
        public void SendEmptyString_ReturnFalse()
        {
            var isBalanced = _service.CheckBalance(String.Empty);

            Assert.False(isBalanced);
        }

        [Fact]
        public void CloseParenthesisFirst_ReturnFalse()
        {
            var isBalanced = _service.CheckBalance(")(");

            Assert.False(isBalanced);
        }

        [Fact]
        public void CloseBracketsFirst_ReturnFalse()
        {
            var isBalanced = _service.CheckBalance("][");

            Assert.False(isBalanced);
        }

        [Fact]
        public void CloseCurlyBracketsFirst_ReturnFalse()
        {
            var isBalanced = _service.CheckBalance("}{");

            Assert.False(isBalanced);
        }

        [Fact]
        public void IncorrectParenthesisBalance_ReturnFalse()
        {
            var isBalanced = _service.CheckBalance("((({}{}))()");

            Assert.False(isBalanced);
        }

        [Fact]
        public void IncorrectBalanceWithNumber_ReturnFalse()
        {
            var isBalanced = _service.CheckBalance("(1((23{[}452{})))(425)");

            Assert.False(isBalanced);
        }

        [Fact]
        public void IncorrectBalanceWithLetter_ReturnFalse()
        {
            var isBalanced = _service.CheckBalance("(azc((acv{}lkhjg{}){)){}(wrrty)");

            Assert.False(isBalanced);
        }

        [Fact]
        public void IncorrectBalanceMatch_ReturnFalse()
        {
            var isBalanced = _service.CheckBalance("({[(])})");

            Assert.False(isBalanced);
        }
        #endregion

        #region True
        [Fact]
        public void CorrectBalanceWithSpace_ReturnTrue()
        {
            var isBalanced = _service.CheckBalance("{[({()})]} [{}]");

            Assert.True(isBalanced);
        }

        [Fact]
        public void CorrectBalanceExample_ReturnTrue()
        {
            var isBalanced = _service.CheckBalance("[{()}](){}");

            Assert.True(isBalanced);
        }
        #endregion
    }
}
