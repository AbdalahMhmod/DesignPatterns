using Command;

var buyCommand = new BuyDepositeCommand();
var transferCommand = new TransferCommand();

var operationInvoker = new OperationInvoker(buyCommand);
operationInvoker.AddCommand(transferCommand);
operationInvoker.ExcuteAllCommands();

operationInvoker.Undo();
operationInvoker.Undo();

/* Summery
   1- Convert requests to objects.
   2- Scheduling these requests.
   3- Can implement retry policy.
   4- Can implemented as one transaction like DB transaction.
   5- Can implement Undo/Redo feature.
 */