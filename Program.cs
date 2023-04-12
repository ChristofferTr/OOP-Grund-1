using System;
using System.Collections.Generic;
using System.Linq;

namespace ATMsystem
{
    public class cardHolder

    {
        String cardNr;
        int pin;
        String firstName;
        String lastName;
        double balance;
        String location;

        public cardHolder(string cardNr, int pin, string firstName, string lastName, double balance)
        {
            this.cardNr = cardNr;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        public String getNr()
        {
            return cardNr;
        }

        public int getPin()
        {
            return pin;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public String getLastName()
        {
            return lastName;
        }

        public double getBalance()
        {
            return balance;
        }

        public void setNr(String newCardnr)
        {
            cardNr = newCardnr;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setFirstName(String newFirstName)
        {
            firstName = newFirstName;
        }

        public void setLastName(String newLastName)
        {
            lastName = newLastName;
        }

        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }

        public static void Main(String[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            void printAlt()
            {
                Console.WriteLine("Please choose what you want to do...");
                Console.WriteLine("1. Show Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("123456", 1234, "Johan", "Grimberg", 4630.50));
            cardHolders.Add(new cardHolder("234567", 2345, "Hugo", "Hill", 3270.50));
            cardHolders.Add(new cardHolder("345678", 3456, "Lina", "Svensson", 7620.50));
            cardHolders.Add(new premiumCardHolder("456789", 4567, "Hailey", "Sween", 6892.50));

            Console.WriteLine("Welcome to SEB.");
            Console.WriteLine("Please insert your card: ");
            String debitCardNum = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNr == debitCardNum);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Invalid card, please try again"); }
                }
                catch { Console.WriteLine("Invalid card, please try again"); }
            }

            Console.WriteLine("Enter your pin: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect pin, please try again."); }
                }
                catch { Console.WriteLine("Incorrect pin, please try again."); }
            }

            if (currentUser is premiumCardHolder)
            {
                Console.WriteLine(((premiumCardHolder)currentUser).getWelcomeMessage());
            }
            else
            {
                Console.WriteLine("Welcome, " + currentUser.getFirstName());
            }
            int option = 0;
            do
            {
                printAlt();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { balance1(currentUser); }
                else if (option == 2) { deposit(currentUser); }
                else if (option == 3) { withdraw(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("Thank you, have a nice day!");
        }

        private static void balance1(cardHolder currentUser)
        {
            if (currentUser is null)
            {
                throw new ArgumentNullException(nameof(currentUser));
            }

            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        private static void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("You don't have enough balance to make this withdrawal");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You have made a withdrawal, thank you!");
            }
        }

        private static void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you, your new balance is: " + currentUser.getBalance());

        }

    }

    public class premiumCardHolder : cardHolder
    {
        public premiumCardHolder(string cardNr, int pin, string firstName, string lastName, double balance)
            : base(cardNr, pin, firstName, lastName, balance)
        {
        }

        public string getWelcomeMessage()
        {
            return "Welcome premium user, " + getFirstName() + "!";
        }
    }






}

