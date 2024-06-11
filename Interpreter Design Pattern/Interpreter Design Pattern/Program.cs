using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Design_Pattern
{
    public interface Expression
    {
        bool interpret(string context);
    }
   
    public class TerminalExpression : Expression
    {
        private string data;

        public TerminalExpression(string data)
        { this.data = data; }

        public bool interpret(string context)
        {
            if (context.Contains(data)) return true;
            return false;
        }

    }

    public class AndExpression : Expression
    {
        private Expression expr1 = null;
        private Expression expr2 = null;

        public AndExpression(Expression expr1, Expression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public bool interpret(string context)
        {
            return expr1.interpret(context) && expr2.interpret(context);
        }
    }

    public class OrExpression : Expression
    {
        private Expression expr1 = null;
        private Expression expr2 = null;

        public OrExpression(Expression expr1, Expression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public bool interpret(string context)
        {
            return expr1.interpret(context) || expr2.interpret(context);
        }
    }
    public  class InpreterApplication
    {
        public static Expression getMaleExpression()
        {
            Expression robert = new TerminalExpression("Robert");
            Expression john = new TerminalExpression("John");
            return new OrExpression(robert, john);
        }

        public static Expression getMarriedWomanExpression()
        {
            Expression julie = new TerminalExpression("Julie");
            Expression married = new TerminalExpression("Married");

            return new AndExpression(julie, married);
        }
        static void Main(string[] args)
        {
            Expression isMale = getMaleExpression();
            Expression isMarried = getMarriedWomanExpression();

            Console.WriteLine($"John is male? {isMale.interpret("John")} ");
            Console.WriteLine($"Julie is married? {isMarried.interpret("Julie Married")} ");

        }
    }
}
