namespace MyApp;

public class BalancingBrackets
{
    //Balancing Brackets (Prefix Sum Trick)
    public bool IsBalanceBruteForce(string input)
    {
        int balance = 0;
        foreach (char tmp in input)
        {
            if (tmp == input[0])
            {
                balance++;
            }
            else
            {
                balance--;
                if (balance < 0)
                {
                    return false;
                }
            }
        }

        return balance == 0;
    }
}