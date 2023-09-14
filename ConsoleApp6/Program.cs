using System.Text.RegularExpressions;

namespace ConsoleApp6
{
    internal class Program
    {
        public static void Reg(string login, string password, string confirmPassword)
        {
           //rongLoginException wrongLoginException= new WrongLoginException();
            if (!IsLoginValid(login))
            {
                Console.WriteLine("Логин содержит недопустимые символы.");
                throw new WrongLoginException();
                return;




            }


        
               if (!IsPasswordValid(password, confirmPassword))
                {
                    Console.WriteLine("Пароль не соответствует требованиям.");
        
                throw new WrongPasswordException();
                    return;
                }

        }

       public static bool IsLoginValid(string login)
       {
          Regex regex = new Regex(@"^[A-Za-z0-9_]+$");
            bool isLengthValid = login.Length < 20;
            if (regex.IsMatch(login) && isLengthValid)
              return true;
          else
              return false;
       }


        public static bool IsPasswordValid(string password, string confirmPassword)
        {
            // Проверка на соответствие требуемым правилам
            bool isLengthValid = password.Length < 20;
            bool isCharactersValid = System.Text.RegularExpressions.Regex.IsMatch(password, @"^[A-Za-z0-9_]+$");
            bool isMatch = password == confirmPassword;

            // Возвращаем результат проверки
            if (isLengthValid && isCharactersValid && isMatch)
                return true;
            else
                return false;
                    
        }


       static void Main()
       {
            try
            {
                Console.WriteLine("Введите логин: ");
                string login = Console.ReadLine();

                Console.WriteLine("Введите пароль: ");
                string pasword = Console.ReadLine();

                Console.WriteLine("Подтвердите пароль!: ");
                string confirmPassword = Console.ReadLine();
                Reg(login, pasword, confirmPassword);
            }
            catch(WrongPasswordException e) 
            {
                Console.WriteLine(e.Message,e.HelpLink);
                Main();
                Console.ReadLine();


            }
            catch (WrongLoginException e)
            {
                Console.WriteLine(e.Message, e.HelpLink);
                Main();
                Console.ReadLine();


            }
        }
    }

    [Serializable]
    public class WrongPasswordException :ApplicationException
    {
        public WrongPasswordException()
        {
        }

        public WrongPasswordException(string message) : base(message)
        {
        }
       
        protected WrongPasswordException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
    [Serializable]
    public class WrongLoginException : ApplicationException
    {
        public WrongLoginException()
        {
        }

        public WrongLoginException(string message) : base(message)
        {
        }
        protected WrongLoginException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
