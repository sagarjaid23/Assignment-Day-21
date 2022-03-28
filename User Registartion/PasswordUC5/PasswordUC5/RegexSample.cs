using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordUC5
{
    class RegexSample
    {
        

        public void Validating()
        {
            
            Console.WriteLine("Validating the first name");
            ValidatingFirstName();
            Console.WriteLine("Validating The Last Name");
            ValidatingLastName();
            Console.WriteLine("Validating Email");
            ValidatingEmail();
            Console.WriteLine("Validating Mobile Number");
            ValidatingMobileNo();
            Console.WriteLine("Validating Password");
            ValidatingPassWord();

        }



        public void ValidatingFirstName()
        {
            string pattern = "^[A-Za-z]{2,}$";
            Regex Regex = new Regex(pattern);
            Console.WriteLine("Enter the first name:");
            string input = Console.ReadLine();
            bool res = Regex.IsMatch(input);
            if (res)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }

        public void ValidatingLastName()
        {
            string pattern = "^[A-Za-z]{2,}$";
            Regex regex = new Regex(pattern);
            Console.WriteLine("Enter the last name : ");
            string input1 = Console.ReadLine();
            bool res1 = regex.IsMatch(input1);
            if (res1)
            {
                Console.WriteLine("Valid!");
            }
            else
            {
                Console.WriteLine("Invalid!");
            }
        }

        public void ValidatingEmail()
        {
            string emailPattern = @"^[a-zA-Z0-9]+([\.\+\-][a-zA-Z0-9]+)?@[a-zA-Z0-9-]+(\.[a-zA-Z]{2,}(\.[a-zA-Z]+)?)$";
            Regex regex = new Regex(emailPattern);
            Console.WriteLine("Enter the Email : ");
            string input1 = Console.ReadLine();
            bool res1 = regex.IsMatch(input1);
            if (res1)
            {
                Console.WriteLine("Valid!");
            }
            else
            {
                Console.WriteLine("Invalid!");
            }
        }

        public void ValidatingMobileNo()
        {
            string MobileNoPattern = "[0-9]{10}$";
            Regex regex = new Regex(MobileNoPattern);
            Console.WriteLine("Enter the Mobile Number: ");
            string input1 = Console.ReadLine();
            bool res1 = regex.IsMatch(input1);
            if (res1)
            {
                Console.WriteLine("Valid!");
            }
            else
            {
                Console.WriteLine("Invalid!");
            }
        }
        public void ValidatingPassWord()
        {
            string passwordPattern = @"[a-z,A-Z,0-9]{8,}$";
            Regex regex = new Regex(passwordPattern);
            Console.WriteLine("Enter password minimum 8 characters");
            string password = Console.ReadLine();
            bool res = regex.IsMatch(password);
            if (res)
            {
                Console.WriteLine("Password valid");
            }
            else
            {
                Console.WriteLine("invalid password");
            }

        }
    
    }
}
