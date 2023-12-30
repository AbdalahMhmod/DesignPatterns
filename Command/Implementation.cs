namespace Command
{
    /// <summary>
    /// Abstract Command
    /// </summary>
    public interface ICommand
    {
        void Excute();
        void Undo();
    }

    /// <summary>
    /// Concrete Commands
    /// </summary>
    public class BuyDepositeCommand : ICommand
    {
        private readonly AccountOperation _accountOperation = new AccountOperation();
        public void Excute()
        {
            _accountOperation.BuyDeposite();
        }

        public void Undo()
        {
            Console.WriteLine("Undo buy deposite");
        }
    }

    public class TransferCommand : ICommand
    {
        private readonly AccountOperation _accountOperation = new AccountOperation();
        public void Excute()
        {
            _accountOperation.Transfer();
        }

        public void Undo()
        {
            Console.WriteLine("Undo transfer");
        }
    }

    /// <summary>
    /// Reciever
    /// </summary>
    public class AccountOperation
    {
        public void AccountQuery()
        {
            Console.WriteLine("Show account data...");
        }

        public void AccountDataToEmail()
        {
            Console.WriteLine("Data sent to email");
        }

        public void BuyDeposite()
        {
            Console.WriteLine("Buy done....");
        }

        public void Transfer()
        {
            Console.WriteLine("Transfer done...");
        }
    }

    /// <summary>
    /// Command Invoker
    /// </summary>
    public class OperationInvoker
    {
        private readonly Stack<ICommand> _commands = new Stack<ICommand>();
        public OperationInvoker(ICommand command)
        {
            _commands.Push(command);
        }

        public void AddCommand(ICommand command)
        {
            _commands.Push(command);
        }

        public void Excute()
        {
            var lastCommand = _commands.LastOrDefault();
            if(lastCommand is null)
            {
                Console.WriteLine("Cannot Excute, Empty command list!");
                return;
            }

            // You can add extra details about the request before and after the excution such as setting excution date.
            Excute(lastCommand);
        }

        public void Excute(ICommand command)
        {
            command.Excute();
        }

        public void ExcuteAllCommands()
        {
            foreach(var command in _commands)
            {
                Excute(command);
            }
        }

        public void Undo()
        {
            var lastCommand = _commands.Pop();
            lastCommand.Undo();
        }
    }
}
