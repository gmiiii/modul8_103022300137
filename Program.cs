class program
{
    static void Main(string[] args)
    {
        
        BankTransferConfig config = BankTransferConfig.Load();

        Console.Write("Pilih bahasa (En/Id): ");
        string language = Console.ReadLine().ToLower();
        config.switchLanguage(language);


        if (config.lang == "id")
        {
            Console.Write("Masukkan jumlah uang yang akan ditransfer: ");
            int input = int.Parse(Console.ReadLine());
            if (input < config.transfer.threshold)
            {
                Console.WriteLine($"Biaya transfer: {config.transfer.low_fee}");
            }
            else
            {
                Console.WriteLine($"Biaya transfer: {config.transfer.high_fee}");
            }
            config.transferFee(input);
        }
        else if (config.lang == "en")
        {
            Console.Write("Please insert the amount of money to transfer: ");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input < config.transfer.threshold)
            {
                Console.WriteLine($"Transfer fee: {config.transfer.low_fee}");
            }
            else
            {
                Console.WriteLine($"Transfer fee: {config.transfer.high_fee}");
            }
            config.transferFee(input);
        }

        config.methodTransfer();
        config.Confirmation();
    }
}