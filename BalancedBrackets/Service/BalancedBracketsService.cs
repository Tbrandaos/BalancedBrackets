using System;
using System.Collections;

namespace BalancedBrackets.Service
{
    public class BalancedBracketsService
    {
        public bool CheckBalance(string request)
        {
            if (String.IsNullOrEmpty(request)) return false;
            try
            {
                Stack stack = new();

                for (int i = 0; i < request.Length; i++)
                {
                    if (request[i] == ' ') continue;
                    if (request[i].ToString() == "{"
                       || request[i].ToString() == "("
                       || request[i].ToString() == "[")
                    {
                        stack.Push(request[i].ToString());
                    }
                    else if (stack.Count > 0)
                    {
                        if (request[i].ToString() == "}")
                        {
                            if (stack.Peek().ToString() == "{") stack.Pop();
                            else return false;
                        }
                        else if (request[i].ToString() == "]")
                        {
                            if (stack.Peek().ToString() == "[") stack.Pop();
                            else return false;
                        }
                        else if (request[i].ToString() == ")")
                        {
                            if (stack.Peek().ToString() == "(") stack.Pop();
                            else return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                if (stack.Count > 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
