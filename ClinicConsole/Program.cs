using ClinicServiceNamespace;
using System.Data;

namespace ClinicConsole
{

    partial class Program
    {

    }

    partial class Program
    {
        static void DoProcess()
        {

        }

    }

    partial class Program
    {

    }

    partial class Program
    {

    }

    internal partial class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Нажмите 1, чтобы загрузить всех клиентов; " +
                    "\n2 - чтобы удалить клиента; " +
                    "\n3 - Создать клиента; " +
                    "\n4 - обновить клиента; " +
                    "\n5 - выйти");

                String res = Console.ReadLine();


                ClinicClient clinicClient = new ClinicClient("http://localhost:5115/", new HttpClient());

                if (res == "1")
                {
                    List<Client> clients = clinicClient.ClientGetAllAsync().Result.ToList();
                    foreach (Client client in clients)
                    {
                        Console.WriteLine("Фамилия: " + client.SurName);
                        Console.WriteLine("Имя: " + client.FirstName);
                        Console.WriteLine("Отчество: " + client.Patronymic);
                        Console.WriteLine("Дата рождения: " + client.Birthday.DateTime);
                        Console.WriteLine("Документ: " + client.Document);
                        Console.WriteLine();
                    }
                }
                else if (res == "2")
                {
                    Console.WriteLine("Введите id клиента, которого хотите удалить");                    
                    int clientId = Int32.Parse(Console.ReadLine());
                    clinicClient.DeleteAsync(clientId);
                    Console.WriteLine($"Клиент с id:{clientId} удален");
                }
                
                else if (res == "3")
                {
                    CreateClientRequest request = new CreateClientRequest();
                    Console.WriteLine("Документ: ");
                    request.Document = Console.ReadLine();
                    Console.WriteLine("Фамилия: ");
                    request.SurName = Console.ReadLine();
                    Console.WriteLine("Имя: ");
                    request.FirstName = Console.ReadLine();
                    Console.WriteLine("Отчество: ");
                    request.Patronymic = Console.ReadLine();
                    Console.WriteLine("Дата рождения: ");   
                    request.Birthday = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();
                    clinicClient.CreateAsync(request);
                }

                else if (res == "4")
                {
                    UpdateClientRequest request = new UpdateClientRequest();
                    Console.WriteLine("Id клиента: ");
                    request.ClientId = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Документ: ");
                    request.Document = Console.ReadLine();
                    Console.WriteLine("Фамилия: ");
                    request.SurName = Console.ReadLine();
                    Console.WriteLine("Имя: ");
                    request.FirstName = Console.ReadLine();
                    Console.WriteLine("Отчество: ");
                    request.Patronymic = Console.ReadLine();
                    Console.WriteLine("Дата рождения: ");
                    request.Birthday = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();
                    clinicClient.EditAsync(request);
                }

                else if(res == "5")
                {
                    break;
                }
            }
            

        }
    }
}