using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class transfer { 
    public int threshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }
}

public class confirmation
{
    public string en { get; set; }
    public string id { get; set; }
}

public class BankTransferConfig
{
    public string lang { get; set; }
    public transfer transfer { get; set; }
    public List<string> methods { get; set; }
    public confirmation confirmation { get; set; }

    public static BankTransferConfig Load()
    {
        String configPath = @"bank_transfer_config.json";
        if (!File.Exists(configPath))
        {
            throw new FileNotFoundException($"Configuration file not found: {configPath}");
        }
        else
        {
            Console.WriteLine($"Configuration file found: {configPath}");
            string json = File.ReadAllText(configPath);
            return JsonSerializer.Deserialize<BankTransferConfig>(json);
        }
    }

    public void Save(string filePath)
    {
        string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public void switchLanguage(string language)
    {
        if (language == "en")
        {
            lang = "en";
            Console.WriteLine($"Language switched to English");
            Console.Write("Please insert the amount of money to transfer: ");

        }
        else if (language == "id")
        {
            lang = "id";
            Console.WriteLine($"Bahasa diubah ke Bahasa Indonesia");
            Console.Write("Masukkan jumlah uang yang akan di - transfer:");
        }
        else
        {
            Console.WriteLine($"Invalid language selection");
        }
    }

    public void transferFee(int input)
    {
        if (lang == "id")
        {
            if (input < transfer.threshold)
            {
                Console.WriteLine($"Total Biaya transfer: {transfer.low_fee + input}");
            }
            else
            {
                Console.WriteLine($"Total Biaya transfer: {transfer.high_fee + input}");
            }
        }
        else if (lang == "en")
        {
            if (input < transfer.threshold)
            {
                Console.WriteLine($"Total transfer fee: {transfer.low_fee + input}");
            }
            else
            {
                Console.WriteLine($"Total transfer fee: {transfer.high_fee + input}");
            }
        }
    }

    public void methodTransfer()
    {
        if (lang == "id")
        {
            Console.WriteLine("Pilih metode transfer:");
            Console.WriteLine($"1. {methods[0]}");
            Console.WriteLine($"2. {methods[1]}");
            Console.WriteLine($"3. {methods[2]}");
            Console.WriteLine($"4. {methods[3]}");
            Console.Write("Pilih metode: ");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Console.WriteLine($"Metode transfer yang dipilih adalah: {methods[0]}");
            }
            else if (input == 2)
            {
                Console.WriteLine($"Metode transfer yang dipilih adalah: {methods[1]}");
            }
            else if (input == 3)
            {
                Console.WriteLine($"Metode transfer yang dipilih adalah: {methods[2]}");
            }
            else if (input == 4)
            {
                Console.WriteLine($"Metode transfer yang dipilih adalah: {methods[3]}");
               
            }


        }
        else if (lang == "en")
        {
            Console.WriteLine("Choose transfer method:");
            Console.WriteLine($"1. {methods[0]}");
            Console.WriteLine($"2. {methods[1]}");
            Console.WriteLine($"3. {methods[2]}");
            Console.WriteLine($"4. {methods[3]}");
            Console.Write("Choose method: ");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Console.WriteLine($"Selected transfer method is: {methods[0]}");
            }
            else if (input == 2)
            {
                Console.WriteLine($"Selected transfer method is: {methods[1]}");
            }
            else if (input == 3)
            {
                Console.WriteLine($"Selected transfer method is: {methods[2]}");
            }
            else if (input == 4)
            {
                Console.WriteLine($"Selected transfer method is: {methods[3]}");

            }
        }
    }

    public void Confirmation()
    {
        if (lang == "id")
        {
            Console.Write($"Konfirmasi transfer: ");
            String input = Console.ReadLine();
            if (input == confirmation.id)
            {
                Console.WriteLine($"Transfer dikonfirmasi");
            }
            else if (input == "tidak")
            {
                Console.WriteLine($"Transfer dibatalkan");
            }
            else
            {
                Console.WriteLine($"Konfirmasi tidak valid");
            }
        }
        else if (lang == "en")
        {
            Console.Write($"Transfer confirmation: ");
            String input = Console.ReadLine();
            if (input == confirmation.en)
            {
                Console.WriteLine($"Transfer confirmed");
            }
            else if (input == "no")
            {
                Console.WriteLine($"Transfer cancelled");
            }
            else
            {
                Console.WriteLine($"Invalid confirmation");
            }
        }
    }

}

